using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсова
{
    public class ArrayLabelRepresenter : IDisposable
    {
        public Point Location;
        public int Count { get; }
        private Form _form;
        private int[] values;
        private Label[] representation;
        
        /// <summary>
        /// Клас, призначений для відобреження масиву чисел за допомогою лейблочок
        /// </summary>
        /// <param name="form">Форма, в яку виводити</param>
        /// <param name="location">Стартова точка розміщення</param>
        public ArrayLabelRepresenter(Form form, Point location)
        {
            this._form = form;
            this.Location = location;
            this.values = Program.InputedArray.ToArray();
            this.Count = values.Length;
            representation = new Label[values.Length+1];
            ResetCellPositions();
        }
        
        /// <summary>
        /// перевантажимо оператор індексації, аби повертав значення масиву за даним індексом
        /// </summary>
        /// <param name="index">Індекс шуканого числа в масиві</param>
        public int this[int index] => values[index];

        /// <summary>
        /// перевантажимо оператор індексації, аби при передаванні двох індексів повертав посилання на лейблочки за даними індексами
        /// </summary>
        /// <param name="first">Індекс першої лейбли</param>
        /// <param name="second">Індекс другої лейбли</param>
        public (Label, Label) this[int first, int second] => (representation[first], representation[second]);

        /// <summary>
        /// міняє місцями два елементи масиву та лейбли, що за них відповідають
        /// </summary>
        /// <param name="i1">індекс першого елементу</param>
        /// <param name="i2">індекс другого елементу</param>
        public void Swap(int i1, int i2)
        {
            (values[i1], values[i2]) = (values[i2], values[i1]);
            (representation[i1], representation[i2]) = (representation[i2], representation[i1]);
        }

        /// <summary>
        /// при знищенні об'єкту видаляти всі лейбли
        /// </summary>
        public void Dispose()
        {
            foreach (Label cell in representation)
            {
                _form.Controls.Remove(cell);
            }
        }

        /// <summary>
        /// перерозташовує лейбли відповідно до значень масиву
        /// </summary>
        /// <param name="hard">Параметр, що вказує, чи перезаписувати збережені об'єкти масивом, що міститься у класі Prodram</param>
        public void ResetCellPositions(bool hard = true)
        {
            if (hard) this.values = Program.InputedArray.ToArray(); // за потреби, перезаписує збережений масив
            foreach (Label cell in representation) // видаляємо поточні лейбли
            {
                _form.Controls.Remove(cell);
            }

            int i;
            for(i = 0; i < values.Length; i++) // створюємо купу лейблочок з необхідними даними та стилем та розміщуємо їх на формі 
            {
                representation[i] = new Label();
                representation[i].Font = Style.StandardFont;
                representation[i].Text = "" + values[i];
                representation[i].BackColor = Style.StandardCellBgColor;
                representation[i].ForeColor = Style.StandardCellFgColor;
                representation[i].TextAlign = ContentAlignment.MiddleCenter;
                representation[i].Size = Style.CellSize;
                representation[i].Location = new Point(this.Location.X+(i%8)*(Style.CellSize.Width+3), this.Location.Y+(i/8)*(Style.CellSize.Height+20)); // вираховуємо розташування. В ряду не більше 8 елементів
                _form.Controls.Add(representation[i]);
            }

            if (i%8 > 0) i+=8; // знизу додамо порожню лейблочку, яка, за потреби, розтягне вікно ще сильніше, аби нижній ряд не був "приклеєний" до дна
            _form.Controls.Add(new Label(){Size = new Size(0,0), Location = new Point(this.Location.X+i%8*(Style.CellSize.Width+3), this.Location.Y+i/8*(Style.CellSize.Height+20))});
        }

        /// <summary>
        /// Отримання швидкого результату сортування, пропускаючи покроковість
        /// </summary>
        public void GetQuickResult()
        {
            Array.Sort(values);
            ResetCellPositions(false);
        }
    }
}