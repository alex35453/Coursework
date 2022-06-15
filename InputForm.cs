using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курсова
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();
        }

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

        private void Confirm(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("Are you sure you want to delete the directory: \"C:/\"?", "Deleting Windows",
                MessageBoxButtons.OKCancel);
            MessageBox.Show(resp == DialogResult.Cancel ? "А просив же не лізти 🙃" : "Ага, і лінукс поставлю..", "Не чіпай поки конфірм");
        }

        private void Clear(object sender, EventArgs e)
        {
            Program.InputedArray = new List<int>();
            SetArrayLabelText();
            this.RemoveButton.Enabled = false;
            this.ClearButton.Enabled = false;
            CancelToRemove(sender, e);
        }

        private void FromFile(object sender, EventArgs e)
        {
            CancelToRemove(sender, e);
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "csv files (*.csv)|*.csv";
            dialog.FilterIndex = 2;
            dialog.RestoreDirectory = true;

            string pathToFile;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                pathToFile = dialog.FileName;
                if (FileReader.FileIsValid(pathToFile))
                {
                    while (true)
                    {
                        try
                        {
                            List<int> content = FileReader.GetContent(pathToFile);
                            if (Program.InputedArray.Count > 0 &&
                                MessageBox.Show("Do you want to add numbers from file to the end of current array?", "Your array is not empty!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                foreach (int number in content) Program.InputedArray.Add(number);
                            }
                            else Program.InputedArray = content;
                            SetArrayLabelText();
                        }
                        catch (Exception)
                        {
                            if (MessageBox.Show("An error occured while parsing this file! Try again?", "Try again?",
                                    MessageBoxButtons.YesNo) ==
                                DialogResult.Yes)
                            {
                                continue;
                            }
                        }

                        break;
                    }
                }
                else MessageBox.Show("Incorrect file!");
                dialog.Dispose();
            }

            if (Program.InputedArray.Count > 0)
            {
                this.RemoveButton.Enabled = true;
                this.ClearButton.Enabled = true;
            }
        }

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

        private void SetArrayLabelText()
        {
            string arrayRepresentation = "";
            int[] array = Program.InputedArray.ToArray();
            if (array.Length > 0)
            {
                arrayRepresentation += array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    arrayRepresentation += ", " + array[i];
                }

                if (arrayRepresentation.Length >= 145)
                {
                    arrayRepresentation = arrayRepresentation.Substring(arrayRepresentation.Length - 145);
                    int ind = arrayRepresentation.IndexOf(',');
                    if (ind > -1) arrayRepresentation = "..." + arrayRepresentation.Substring(ind);
                }
            }
            this.ArrayLabel.Text = "Array: " + arrayRepresentation;
            this.ArrayLabel.Refresh();
        }
        
        private void TextBoxEnterDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                Add(sender, e);
            }
        }

        private int selectedIndex;
    }
}