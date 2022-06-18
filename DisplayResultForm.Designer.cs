namespace Курсова
{
    partial class DisplayResultForm
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
            this.GoBackButton = new System.Windows.Forms.Button();
            this.StartSortingButton = new System.Windows.Forms.Button();
            this.PauseButton = new System.Windows.Forms.Button();
            this.ContinueButton = new System.Windows.Forms.Button();
            this.QuickResultButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GoBackButton
            // 
            this.GoBackButton.Font = Style.TitleFont;
            this.GoBackButton.Location = new System.Drawing.Point(0, 1);
            this.GoBackButton.Name = "GoBackButton";
            this.GoBackButton.Size = new System.Drawing.Size(41, 30);
            this.GoBackButton.TabIndex = 1;
            this.GoBackButton.Text = "<";
            this.GoBackButton.BackColor = Style.ActionButtonBgColor;
            this.GoBackButton.ForeColor = Style.ActionButtonFgColor;
            this.GoBackButton.Click += new System.EventHandler(this.GoBack);
            // 
            // StartSortingButton
            // 
            this.StartSortingButton.Font = Style.ButtonFont;
            this.StartSortingButton.Location = new System.Drawing.Point(107, 11);
            this.StartSortingButton.Name = "StartSortingButton";
            this.StartSortingButton.Size = new System.Drawing.Size(185, 48);
            this.StartSortingButton.TabIndex = 2;
            this.StartSortingButton.Text = "📊 Start sorting  ";
            this.StartSortingButton.BackColor = Style.ActionButtonBgColor;
            this.StartSortingButton.ForeColor = Style.ActionButtonFgColor;
            this.StartSortingButton.Click += new System.EventHandler(this.StartSorting);
            // 
            // PauseButton
            // 
            this.PauseButton.Font = Style.ButtonFont;
            this.PauseButton.Location = new System.Drawing.Point(298, 11);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(185, 48);
            this.PauseButton.TabIndex = 3;
            this.PauseButton.Text = "⏸ Pause  ";
            this.PauseButton.Enabled = false;
            this.PauseButton.BackColor = Style.RemoveButtonBgColor;
            this.PauseButton.ForeColor = Style.RemoveButtonFgColor;
            this.PauseButton.Click += new System.EventHandler(this.Pause);
            // 
            // ContinueButton
            // 
            this.ContinueButton.Font = Style.ButtonFont;
            this.ContinueButton.Location = new System.Drawing.Point(298, 12);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(185, 48);
            this.ContinueButton.TabIndex = 4;
            this.ContinueButton.Text = "▶ Continue  ";
            this.ContinueButton.Visible = false;
            this.ContinueButton.BackColor = Style.ConfirmButtonBgColor;
            this.ContinueButton.ForeColor = Style.ConfirmButtonFgColor;
            this.ContinueButton.Click += new System.EventHandler(this.Continue);
            // 
            // QuickResultButton
            // 
            this.QuickResultButton.Font = Style.ButtonFont;
            this.QuickResultButton.Location = new System.Drawing.Point(489, 12);
            this.QuickResultButton.Name = "QuickResultButton";
            this.QuickResultButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.QuickResultButton.Size = new System.Drawing.Size(185, 48);
            this.QuickResultButton.TabIndex = 5;
            this.QuickResultButton.Text = "⌚ Quick result  ";
            this.QuickResultButton.BackColor = Style.StandardButtonBgColor;
            this.QuickResultButton.ForeColor = Style.StandardButtonFgColor;
            this.QuickResultButton.Click += new System.EventHandler(this.QuickResult);
            // 
            // DisplayResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.QuickResultButton);
            this.Controls.Add(this.ContinueButton);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.StartSortingButton);
            this.Controls.Add(this.GoBackButton);
            this.Name = "InputForm";
            this.Text = "Sorting";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button QuickResultButton;
        private System.Windows.Forms.Button StartSortingButton;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.Button GoBackButton;
        
        #endregion
    }
}