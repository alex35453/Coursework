using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Курсова
{
    public partial class DisplayResultForm : Form
    {
        private ArrayLabelRepresenter representer;
        private Timer WaitBetweenIterations = new Timer();
        private Timer WaitBeforePaint = new Timer();
        private Timer WaitBeforeUnpaint = new Timer();
        private List<Timer> ManuallyStopped;

        private int i;
        private int j;
        public DisplayResultForm()
        {
            InitializeComponent();
            representer = new ArrayLabelRepresenter(this, new Point(120, 200), new Size(500, 50));
            WaitBetweenIterations.Interval = 500;
            WaitBetweenIterations.Tick += NewIteration;
            
            WaitBeforePaint.Interval = 250;
            WaitBeforePaint.Tick += CheckSelected;
            
            WaitBeforeUnpaint.Interval = 250;
            WaitBeforeUnpaint.Tick += UnpaintSelected;
        }
        private void GoBack(object sender, EventArgs e)
        {
            Program.IsClosedByUser = false;
            this.Close();
        }

        private void Pause(object sender, EventArgs e)
        {
            this.ContinueButton.Show();
            this.PauseButton.Hide();
            foreach (Timer t in new Timer[]{ WaitBeforePaint, WaitBeforeUnpaint, WaitBetweenIterations })
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
            this.StartSortibgButton.Text = "Restart";
            this.representer.ResetCellPositions();
            WaitBetweenIterations.Start();
        }

        private void Continue(object sender, EventArgs e)
        {
            foreach (Timer t in ManuallyStopped)
            {
                t.Start();
            }
            this.ContinueButton.Hide();
            this.PauseButton.Show();
        }

        private void QuickResult(object sender, EventArgs e)
        {
            this.Pause(sender, e);
            representer.GetQuickResult();
            this.PauseButton.Enabled = false;
            this.StartSortibgButton.Text = "Start sorting";
            this.PauseButton.Show();
            this.ContinueButton.Hide();
        }

        private void NewIteration(Object timer, EventArgs e)
        {
            this.WaitBetweenIterations.Stop();
            this.WaitBeforePaint.Start();
            (Label first, Label second) = representer[i, i + 1];
            first.BorderStyle = BorderStyle.FixedSingle;
            second.BorderStyle = BorderStyle.FixedSingle;
        }
        
        private void CheckSelected(Object timer, EventArgs e)
        {
            this.WaitBeforePaint.Stop();
            (Label first, Label second) = representer[i, i + 1];
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
                
                WaitBeforeUnpaint.Start();
            }
            
        }
        
        private void UnpaintSelected(Object timer, EventArgs e)
        {
            this.WaitBeforeUnpaint.Stop();
            (Label first, Label second) = representer[i, i + 1];
            
            first.BackColor = Style.StandardCellBgColor;
            first.ForeColor = Style.StandardCellFgColor;
            second.BackColor = Style.StandardCellBgColor;
            second.ForeColor = Style.StandardCellFgColor;

            first.BorderStyle = BorderStyle.None;
            second.BorderStyle = BorderStyle.None;
            
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
                this.StartSortibgButton.Text = "Start sorting";
            }
        }
    }
}