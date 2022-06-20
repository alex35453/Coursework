using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курсова
{
    public partial class InputForm : Form
    {
        /// <summary>
        /// Форма, призначена для користувацього вводу масиву
        /// </summary>
        public InputForm()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Приховує елементи форми, призначені для введення чисел та відкриває кнопки для видалення
        /// </summary>
        private void ToRemove(object sender, EventArgs e)
        {
            this.AddButton.Visible = false;
            this.EnterNewElementTextBox.Visible = false;
            this.NextButton.Visible = true;
            this.NextButton.Enabled = false;
            this.PreviousButton.Visible = true;
            this.PreviousButton.Enabled = Program.InputedArray.Count > 1;
            this.SelectedElementLabel.Visible = true;
            this.selectedIndex = Program.InputedArray.Count - 1;
            this.SelectedElementLabel.Text = "" + Program.InputedArray[selectedIndex];
            this.ConfirmRemoveButton.Visible = true;
            CancelRemoveButton.Visible = true;
            this.RemoveButton.Visible = false;
        }
        
        /// <summary>
        /// видпляє обраний елемент з масиву та оновлює відображення 
        /// </summary>
        private void ConfirmRemove(object sender, EventArgs e)
        {
            Program.InputedArray.RemoveAt(selectedIndex);
            SetArrayLabelText();
            if (Program.InputedArray.Count == 0)
            {
                this.RemoveButton.Enabled = false;
                this.ClearButton.Enabled = false;
            }
            CancelToRemove(sender, e);
        }
        
        /// <summary>
        /// Приховує елементи форми, призначені для видалення чисел та відкриває кнопки для додавання
        /// </summary>
        private void CancelToRemove(object sender, EventArgs e)
        {
            this.ConfirmRemoveButton.Visible = false;
            this.RemoveButton.Visible = true;
            
            this.AddButton.Visible = true;
            this.EnterNewElementTextBox.Visible = true;
            this.NextButton.Visible = false;
            this.PreviousButton.Visible = false;
            this.SelectedElementLabel.Visible = false;
            this.CancelRemoveButton.Visible = false;
        }
        
        
        /// <summary>
        /// обирає попередній елемент масиву від поточного і відображає його
        /// </summary>
        private void DisplayPrevious(object sender, EventArgs e)
        {
            selectedIndex--;
            NextButton.Enabled = true;
            if (selectedIndex == 0)
            {
                PreviousButton.Enabled = false;
            }
            this.SelectedElementLabel.Text = ""+Program.InputedArray[selectedIndex];
        }

        /// <summary>
        /// Якщо у нас уведено достатньо значень, переходить до наступної форми
        /// </summary>
        private void Confirm(object sender, EventArgs e)
        {
            if (Program.InputedArray.Count < 2)
            {
                MessageBox.Show("There is nothing to sort! Please, add several elements!", "Not enough elements");
                return;
            }
            this.Hide(); // Ховаємо форму та відображаємо наступну. Не закриваємо її, щоб можна було повернутися на неї кнопкою GoBack
            new DisplayResultForm().ShowDialog();
            if (Program.IsClosedByUser) Close(); // Після відпрацювання і закриття наступної форми перевіряємо, чи програма не закрита натисканням на "X". Якщо так - закриваємо і цю форму, інакше відображаємо
            this.Show();
            Program.IsClosedByUser = true; // присвоюємо прапорцю знову true, щоб при наступному закритті хрестиком коректно все обробити
        }

        /// <summary>
        /// Повністю очищуємо масив та оновлюємо його відображення
        /// </summary>
        private void Clear(object sender, EventArgs e)
        {
            Program.InputedArray = new List<int>();
            SetArrayLabelText();
            this.RemoveButton.Enabled = false;
            this.ClearButton.Enabled = false;
            CancelToRemove(sender, e);
        }

        /// <summary>
        /// Відриваємо системне вікно вибору файлу та, якщо можливо, відкриваємо його і зчитуємо дані,доповнюючи або перезаписуючи масив на вибір користувача
        /// </summary>
        private void FromFile(object sender, EventArgs e)
        {
            CancelToRemove(sender, e);
            OpenFileDialog dialog = new OpenFileDialog(); // системне вікно вибору файлу
            dialog.Filter = "csv files (*.csv)|*.csv"; // приймаємо лише .csv
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true; // наступного разу відкриється на тій папці, де оберемо файл цього разу

            string pathToFile;
            if (dialog.ShowDialog() == DialogResult.OK) // відкриваємо віконечко вибору та, якщо обрано файл:
            {
                // приймаємо файл
                pathToFile = dialog.FileName;
                if (FileReader.FileIsValid(pathToFile)) // якщо валідний, пробуємо зчитати
                {
                    while (true)
                    {
                        try
                        {
                            List<int> content = FileReader.GetContent(pathToFile);
                            if (Program.InputedArray.Count > 0 && // якщо масив непорожній, питаємо, додавати чи перезаписувати. Якщо перше - додаємо
                                MessageBox.Show("Do you want to add numbers from file to the end of current array?", "Your array is not empty!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                foreach (int number in content) Program.InputedArray.Add(number);
                            }
                            else Program.InputedArray = content; // інакше перезаписуємо
                            SetArrayLabelText(); // в будь-якому разі, оновлюємо віжлбраження
                        }
                        catch (Exception)
                        {
                            if (MessageBox.Show("An error occured while parsing this file! Try again?", "Try again?",
                                    MessageBoxButtons.YesNo) ==
                                DialogResult.Yes)
                            {
                                continue; // якшо ловимо еррор - питаємо, чи пробувати ще раз. Якщо так - пробуємо, інакше виходимо.
                            }
                        }

                        break;
                    }
                }
                else MessageBox.Show("Incorrect file!"); // якщо файл невалідний - виводимо відповідне повідомлення
                dialog.Dispose();
            }

            if (Program.InputedArray.Count > 0) // активуємо кновки видалення
            {
                this.RemoveButton.Enabled = true;
                this.ClearButton.Enabled = true;
            }
        }

        /// <summary>
        /// Якщо можливо, додає елемент до масиву, інакше виводить відповідне повідомлення
        /// </summary>
        private void Add(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.EnterNewElementTextBox.Text.Trim()))
            {
                MessageBox.Show("Enter a value first!");
                this.EnterNewElementTextBox.Text = "";
                return;
            }

            if (!int.TryParse(this.EnterNewElementTextBox.Text.Trim(), out int value))
            {
                MessageBox.Show("Incorrect input! Please, enter the integer number!");
                this.EnterNewElementTextBox.Text = "";
                return;
            }

            Program.InputedArray.Add(value);
            this.RemoveButton.Enabled = true;
            this.ClearButton.Enabled = true;
            SetArrayLabelText();
            this.EnterNewElementTextBox.Text = "";
        }

        /// <summary>
        /// обирає наступний елемент масиву від поточного і відображає його
        /// </summary>
        private void DisplayNext(object sender, EventArgs e)
        {
            selectedIndex++;
            PreviousButton.Enabled = true;
            if (selectedIndex == Program.InputedArray.Count-1)
            {
                NextButton.Enabled = false;
            }
            this.SelectedElementLabel.Text = ""+Program.InputedArray[selectedIndex];
        }

        /// <summary>
        /// Оновлює текстове відображення масиву
        /// </summary>
        private void SetArrayLabelText()
        {
            string arrayRepresentation = "";
            int[] array = Program.InputedArray.ToArray();
            if (array.Length > 0)
            {
                arrayRepresentation += array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    arrayRepresentation += ", " + array[i]; // спершу додаємо всі елементи через кому
                }

                if (arrayRepresentation.Length >= 145) // якщо їх надто багато - обтинаємо початок, але не посеред числа, а до якоїсь коми
                {
                    arrayRepresentation = arrayRepresentation.Substring(arrayRepresentation.Length - 145);
                    int ind = arrayRepresentation.IndexOf(',');
                    if (ind > -1) arrayRepresentation = "..." + arrayRepresentation.Substring(ind);
                }
            }
            this.ArrayLabel.Text = "Array: " + arrayRepresentation;
            this.ArrayLabel.Refresh(); // про всяк випадок оновлюємо лейблу, аби текст точно змінився
        }
        
        /// <summary>
        /// додає елементи до масиву при натисканні Enter у текстбоксі
        /// </summary>
        private void TextBoxEnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Add(sender, e);
            }
        }

        /// <summary>
        /// зберігає індекс останнього обраного елементу масиву
        /// </summary>
        private int selectedIndex;
    }
}