using System.Windows.Forms;

namespace Курсова
{
    partial class InputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLabel = new System.Windows.Forms.Label();
            this.ArrayLabel = new System.Windows.Forms.Label();
            this.FromFileButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.ConfirmRemoveButton = new Button();
            this.CancelRemoveButton = new Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.SelectedElementLabel = new System.Windows.Forms.Label();
            this.EnterNewElementTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TitleLabel
            // 
            this.TitleLabel.Font = Style.TitleFont;
            this.TitleLabel.Location = new System.Drawing.Point(141, 45);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(488, 55);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.Text = "Please, enter your array elements or choose a .csv file that contains it:";
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArrayLabel
            // 
            this.ArrayLabel.Font = Style.StandardFont;
            this.ArrayLabel.Location = new System.Drawing.Point(92, 138);
            this.ArrayLabel.Name = "ArrayLabel";
            this.ArrayLabel.Size = new System.Drawing.Size(520, 37);
            this.ArrayLabel.TabIndex = 1;
            this.ArrayLabel.Text = "Array: ";
            this.ArrayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FromFileButton
            // 
            this.FromFileButton.Font = Style.StandardFont;
            this.FromFileButton.Location = new System.Drawing.Point(618, 136);
            this.FromFileButton.Name = "FromFileButton";
            this.FromFileButton.Size = new System.Drawing.Size(120, 39);
            this.FromFileButton.TabIndex = 2;
            this.FromFileButton.Text = "📂 From file  ";
            this.FromFileButton.BackColor = Style.StandardButtonBgColor;
            this.FromFileButton.ForeColor = Style.StandardButtonFgColor;
            this.FromFileButton.Click += new System.EventHandler(this.FromFile);
            // 
            // AddButton
            // 
            this.AddButton.Font = Style.StandardFont;
            this.AddButton.Location = new System.Drawing.Point(417, 225);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(161, 47);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "+ Add  ";
            this.AddButton.BackColor = Style.ActionButtonBgColor;
            this.AddButton.ForeColor = Style.ActionButtonFgColor;
            this.AddButton.Click += new System.EventHandler(this.Add);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = Style.StandardFont;
            this.RemoveButton.Location = new System.Drawing.Point(584, 225);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(154, 47);
            this.RemoveButton.TabIndex = 4;
            this.RemoveButton.Text = "🗑 Remove   ";
            this.RemoveButton.BackColor = Style.RemoveButtonBgColor;
            this.RemoveButton.ForeColor = Style.RemoveButtonFgColor;
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Click += new System.EventHandler(this.ToRemove);
            // 
            // ConfirmRemoveButton
            // 
            this.ConfirmRemoveButton.Font = Style.StandardFont;
            this.ConfirmRemoveButton.Location = new System.Drawing.Point(584, 225);
            this.ConfirmRemoveButton.Name = "ConfirmRemoveButton";
            this.ConfirmRemoveButton.Size = new System.Drawing.Size(154, 47);
            this.ConfirmRemoveButton.TabIndex = 4;
            this.ConfirmRemoveButton.Text = "🗑 Confirm remove ";
            this.ConfirmRemoveButton.BackColor = Style.RemoveButtonBgColor;
            this.ConfirmRemoveButton.ForeColor = Style.RemoveButtonFgColor;
            this.ConfirmRemoveButton.Enabled = true;
            this.ConfirmRemoveButton.Visible = false;
            this.ConfirmRemoveButton.Click += new System.EventHandler(this.ConfirmRemove);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = Style.ButtonFont;
            this.ClearButton.Location = new System.Drawing.Point(92, 329);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(321, 47);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "✕ Clear  ";
            this.ClearButton.Enabled = false;
            this.ClearButton.BackColor = Style.StandardButtonBgColor;
            this.ClearButton.ForeColor = Style.StandardButtonFgColor;
            this.ClearButton.Click += new System.EventHandler(this.Clear);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Font = Style.ButtonFont;
            this.ConfirmButton.Location = new System.Drawing.Point(417, 329);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(321, 47);
            this.ConfirmButton.TabIndex = 6;
            this.ConfirmButton.Text = "✔ Confirm  ";
            this.ConfirmButton.BackColor = Style.ConfirmButtonBgColor;
            this.ConfirmButton.ForeColor = Style.ConfirmButtonFgColor;
            this.ConfirmButton.Click += new System.EventHandler(this.Confirm);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Font = Style.StandardFont;
            this.PreviousButton.Location = new System.Drawing.Point(187, 225);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(113, 47);
            this.PreviousButton.TabIndex = 7;
            this.PreviousButton.Text = "← Previous ";
            this.PreviousButton.BackColor = Style.StandardButtonBgColor;
            this.PreviousButton.ForeColor = Style.StandardButtonFgColor;
            this.PreviousButton.Visible = false;
            this.PreviousButton.Click += new System.EventHandler(this.DisplayPrevious);
            // 
            // NextButton
            // 
            this.NextButton.Font = Style.StandardFont;
            this.NextButton.Location = new System.Drawing.Point(300, 225);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(113, 47);
            this.NextButton.TabIndex = 8;
            this.NextButton.Text = "  Next →";
            this.NextButton.BackColor = Style.StandardButtonBgColor;
            this.NextButton.ForeColor = Style.StandardButtonFgColor;
            this.NextButton.Visible = false;
            this.NextButton.Click += new System.EventHandler(this.DisplayNext);
            // 
            // CancelRemoveButton
            // 
            this.CancelRemoveButton.Font = Style.StandardFont;
            this.CancelRemoveButton.Location = new System.Drawing.Point(417, 225);
            this.CancelRemoveButton.Name = "CancelRemoveButton";
            this.CancelRemoveButton.Size = new System.Drawing.Size(161, 47);
            this.CancelRemoveButton.TabIndex = 8;
            this.CancelRemoveButton.Text = "✕ Cancel ";
            this.CancelRemoveButton.BackColor = Style.StandardButtonBgColor;
            this.CancelRemoveButton.ForeColor = Style.StandardButtonFgColor;
            this.CancelRemoveButton.Visible = false;
            this.CancelRemoveButton.Click += new System.EventHandler(this.CancelToRemove);
            // 
            // SelectedElementLabel
            // 
            this.SelectedElementLabel.Font = Style.StandardFont;
            this.SelectedElementLabel.Location = new System.Drawing.Point(92, 225);
            this.SelectedElementLabel.Name = "SelectedElementLabel";
            this.SelectedElementLabel.Size = new System.Drawing.Size(100, 47);
            this.SelectedElementLabel.TabIndex = 9;
            this.SelectedElementLabel.Visible = false;
            this.SelectedElementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EnterNewElementTextBox
            // 
            this.EnterNewElementTextBox.Font = Style.ButtonFont;
            this.EnterNewElementTextBox.Location = new System.Drawing.Point(92, 231);
            this.EnterNewElementTextBox.Name = "EnterNewElementTextBox";
            this.EnterNewElementTextBox.Size = new System.Drawing.Size(320, 31);
            this.EnterNewElementTextBox.KeyDown += TextBoxEnterDown;
            this.EnterNewElementTextBox.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.EnterNewElementTextBox);
            this.Controls.Add(this.SelectedElementLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ConfirmRemoveButton);
            this.Controls.Add(this.CancelRemoveButton);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.FromFileButton);
            this.Controls.Add(this.ArrayLabel);
            this.Controls.Add(this.TitleLabel);
            this.Name = "InputForm";
            this.Text = "Enter an array";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox EnterNewElementTextBox;
        private System.Windows.Forms.Label SelectedElementLabel;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button ConfirmRemoveButton;
        private System.Windows.Forms.Button CancelRemoveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button FromFileButton;
        private System.Windows.Forms.Label ArrayLabel;
        private System.Windows.Forms.Label TitleLabel;

        #endregion
    }
}