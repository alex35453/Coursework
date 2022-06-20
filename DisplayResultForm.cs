using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Курсова
{
    public partial class DisplayResultForm : Form
    {
        private ArrayLabelRepresenter representer; // об'єкт, що відповідає за відображення масиву лейблами
        
        // Можна все зробити одним таймером, просто видаляючи одні обробники події Tick та додаючи інші, але
        // це неоптимально, тому краще створимо по таймеру на задачу і запускатимемо їх у потрібному порядку
        private Timer WaitBetweenIterations = new Timer(); // очікування перед вибором нової пари елементів
        private Timer WaitBeforePaint = new Timer(); // очікування між вибором елементів та їх перевіркою і розфарбовуванням
        private Timer WaitBeforeSwap = new Timer(); // очікування перед зміною розташувань елементів при сортуванні
        private Timer WaitBeforeUnpaint = new Timer(); // очікування між зафарбуванням і поверненням до початкового кольору
        private Timer MovementDeley = new Timer(); // таймер для реалізації "плавного" переміщення елементів
        
        private List<Timer> ManuallyStopped; // список теймерів, які працювали в момент натискання паузи, тому мають бути відновлені після натискання Continue

        private int i; // змінна для ітерації по елементам масиву
        private int j; // змінна для обмеження ітерації
        private int ctr; // лічильник кроків при переміщенні
        public DisplayResultForm()
        {
            InitializeComponent();
            representer = new ArrayLabelRepresenter(this, CalculateArrayLocation());
            WaitBetweenIterations.Interval = 500;
            WaitBetweenIterations.Tick += NewIteration;
            
            WaitBeforePaint.Interval = 500;
            WaitBeforePaint.Tick += CheckSelected;
            
            WaitBeforeUnpaint.Interval = 500;
            WaitBeforeUnpaint.Tick += UnpaintSelected;

            WaitBeforeSwap.Interval = 500;
            WaitBeforeSwap.Tick += SwapElements;
            
            MovementDeley.Interval = 55;
        }
        
        /// <summary>
        /// повертається до минулої форми шляхом закриття поточної форми, позначаючи це як програмне закриття
        /// </summary>
        private void GoBack(object sender, EventArgs e)
        {
            Program.IsClosedByUser = false;
            this.Close();
        }

        /// <summary>
        /// призупиняє всі таймери і зберігає їх для подальшого відновлення
        /// </summary>
        private void Pause(object sender, EventArgs e)
        {
            this.ContinueButton.Show();
            this.PauseButton.Hide();
            foreach (Timer t in new Timer[]{ WaitBeforePaint, WaitBeforeUnpaint, WaitBetweenIterations, WaitBeforeSwap, MovementDeley })
            {
                if (t.Enabled)
                {
                    ManuallyStopped.Add(t);
                    t.Stop();
                }
            }
        }

        private void StartSorting(object sender, EventArgs e)
        {
            this.Pause(sender, e);
            i = 0;
            j = 1;
            ManuallyStopped = new List<Timer>();
            this.ContinueButton.Hide();
            this.PauseButton.Show();
            this.PauseButton.Enabled = true;
            this.StartSortingButton.Text = "⭯ Restart  ";
            this.representer.ResetCellPositions();
            WaitBetweenIterations.Start();
        }

        /// <summary>
        /// відновлює всі зупинені паузою таймери
        /// </summary>
        private void Continue(object sender, EventArgs e)
        {
            foreach (Timer t in ManuallyStopped)
            {
                t.Start();
            }
            this.ManuallyStopped.Clear();
            this.ContinueButton.Hide();
            this.PauseButton.Show();
        }

        private void QuickResult(object sender, EventArgs e)
        {
            this.Pause(sender, e);
            representer.GetQuickResult();
            this.PauseButton.Enabled = false;
            this.StartSortingButton.Text = "Start sorting";
            this.PauseButton.Show();
            this.ContinueButton.Hide();
        }

        private Label first, second; // лейбли, які потрібно перемістити
        private Point positionBeforeSwap1, positionBeforeSwap2; // при виконанні анімації переміщень елементи не завжди приходять точно у задану точку, тому зберігаємо їх місце початку і призначення, аби потім підрівняти
        
        /// <summary>
        /// виділяємо обрані клітинки і чекаємо розфарбування
        /// </summary>
        private void NewIteration(Object timer, EventArgs e)
        {
            this.WaitBetweenIterations.Stop();
            (first, second) = representer[i, i + 1];
            first.BackColor = Style.SelectedCellBgColor;
            second.BackColor = Style.SelectedCellBgColor;
            first.ForeColor = Style.SelectedCellFgColor;
            second.ForeColor = Style.SelectedCellFgColor;
            this.WaitBeforePaint.Start();
        }
        
        /// <summary>
        /// перевіряємо обрані клітинки, зафарбовуємо їх та чекаємо або на переміщення, або на відновлення кольору
        /// </summary>
        private void CheckSelected(Object timer, EventArgs e)
        {
            this.WaitBeforePaint.Stop();
            if (representer[i] <= representer[i + 1])
            {
                first.BackColor = Style.CorrectOrderedCellBgColor;
                first.ForeColor = Style.CorrectOrderedCellFgColor;
                second.BackColor = Style.CorrectOrderedCellBgColor;
                second.ForeColor = Style.CorrectOrderedCellFgColor;
                
                WaitBeforeUnpaint.Start();
            }
            else
            {
                first.BackColor = Style.IncorrectOrderedCellBgColor;
                first.ForeColor = Style.IncorrectOrderedCellFgColor;
                second.BackColor = Style.IncorrectOrderedCellBgColor;
                second.ForeColor = Style.IncorrectOrderedCellFgColor;
                
                WaitBeforeSwap.Start();
            }
            
        }
        
        /// <summary>
        /// зберігаємо позиції елементів та починаємо розсувати вертикально у різних напрямках, якщо вони у одному рядку, або ж одразу переміщуємо, якщо у різних
        /// </summary>
        private void SwapElements(Object timer, EventArgs e)
        {
            WaitBeforeSwap.Stop();
            representer.Swap(i, i+1);
            positionBeforeSwap1 = first.Location;
            positionBeforeSwap2 = second.Location;
            ctr = 0;
            if ((i + 1) % 8 == 0)
            {
                MovementDeley.Tick += SwapOnBoundary;
            }
            else MovementDeley.Tick += Dilute;
            MovementDeley.Start();
        }
        
        /// <summary>
        /// вертикально розсуваємо елементи на певну відстань
        /// </summary>
        private void Dilute(Object timer, EventArgs e)
        {
            ctr++;
            first.Location = new Point(first.Location.X, first.Location.Y + Style.CellSize.Height / 6);
            second.Location = new Point(second.Location.X, second.Location.Y - Style.CellSize.Height / 6);
            if (ctr >= 5) // коли закінчили розсовувати, починаємо міняти місцями
            {
                MovementDeley.Stop();
                ctr = 0;
                MovementDeley.Tick -= Dilute;
                MovementDeley.Tick += SwapConsistent;
                MovementDeley.Start();
            }
        }
        
        /// <summary>
        /// Коли елементи в різних рядах, плавно міняємо їх місцями не розсовуючи та чекаємо на відновлення кольорів
        /// </summary>
        private void SwapOnBoundary(Object timer, EventArgs e)
        {
            ctr++;
            first.Location = new Point(first.Location.X - (Style.CellSize.Width+5)*7/10 - 1, first.Location.Y + (Style.CellSize.Height+20)/10);
            second.Location = new Point(second.Location.X + (Style.CellSize.Width+5)*7/10, second.Location.Y - (Style.CellSize.Height+20)/10);
            if (ctr == 10)
            {
                ctr = 0;
                MovementDeley.Stop();
                MovementDeley.Tick -= SwapOnBoundary;
                first.Location = positionBeforeSwap2;
                second.Location = positionBeforeSwap1;
                WaitBeforeUnpaint.Start();
            }
        }
        
        /// <summary>
        /// коли елементи в одному ряду, після розсування елементів плавно переміщуємо їх на свої нові вертикалі
        /// </summary>
        private void SwapConsistent(Object timer, EventArgs e)
        {
            ctr++;
            first.Location = new Point(first.Location.X + (Style.CellSize.Width+5) / 5 - 1, first.Location.Y);
            second.Location = new Point(second.Location.X - (Style.CellSize.Width+5) / 5 + 1, second.Location.Y);
            if (ctr == 5)
            {
                ctr = 0;
                first.Location = new Point(positionBeforeSwap2.X, first.Location.Y);
                second.Location = new Point(positionBeforeSwap1.X, second.Location.Y);
                MovementDeley.Tick -= SwapConsistent;
                MovementDeley.Tick += Adjust;
            }
        }
        
        /// <summary>
        /// коли елементи опинилися на своїх вертикалях, вирівнюємо їх в потрібний ряд та чекаємо на відновлення кольору
        /// </summary>
        private void Adjust(Object timer, EventArgs e)
        {
            ctr++;
            first.Location = new Point(first.Location.X, first.Location.Y - Style.CellSize.Height / 6);
            second.Location = new Point(second.Location.X, second.Location.Y + Style.CellSize.Height / 6);
            if (ctr == 5)
            {
                ctr = 0;
                MovementDeley.Tick -= Adjust;
                MovementDeley.Stop();
                first.Location = positionBeforeSwap2;
                second.Location = positionBeforeSwap1;
                WaitBeforeUnpaint.Start();
            }
        }
        
        /// <summary>
        /// відновлюємо колір клітинки до стандартного, знімаємо виділення та, якщо потрібно, чекаємо на наступну ітерацію
        /// </summary>
        private void UnpaintSelected(Object timer, EventArgs e)
        {
            this.WaitBeforeUnpaint.Stop();
            
            first.BackColor = Style.StandardCellBgColor;
            first.ForeColor = Style.StandardCellFgColor;
            second.BackColor = Style.StandardCellBgColor;
            second.ForeColor = Style.StandardCellFgColor;

            if (i < representer.Count - j - 1)
            {
                i++;
            }
            else
            {
                i = 0;
                j++;
            }

            if (j < representer.Count) WaitBetweenIterations.Start();
            else
            {
                this.PauseButton.Enabled = false;
                this.StartSortingButton.Text = "📊 Start sorting  ";
            }
        }

        /// <summary>
        /// вираховуємо початкове положення лейблочок залежно від кількості елементів у масиві
        /// </summary>
        /// <returns>точку початку розміщення лейблочок</returns>
        private Point CalculateArrayLocation()
        {
            if (Program.InputedArray.Count > 48) return new Point(80, 100);
            if (Program.InputedArray.Count >= 8)
                return new Point(80, 250 - (Style.CellSize.Height+20)/2 * ((Program.InputedArray.Count - 1) / 8));
            return new Point(400 - (Style.CellSize.Width+5)/2 * Program.InputedArray.Count, 200);
        }
    }
}