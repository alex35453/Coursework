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
            representer = new ArrayLabelRepresenter(this, GetArrayLocation(), new Size(500, 50));
            WaitBetweenIterations.Interval = 500;
            WaitBetweenIterations.Tick += NewIteration;
            
            WaitBeforePaint.Interval = 500;
            WaitBeforePaint.Tick += CheckSelected;
            
            WaitBeforeUnpaint.Interval = 500;
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
            this.StartSortingButton.Text = "⭯ Restart  ";
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
            this.StartSortingButton.Text = "Start sorting";
            this.PauseButton.Show();
            this.ContinueButton.Hide();
        }

        private void NewIteration(Object timer, EventArgs e)
        {
            this.WaitBetweenIterations.Stop();
            this.WaitBeforePaint.Start();
            (Label first, Label second) = representer[i, i + 1];
            first.BackColor = Style.SelectedCellBgColor;
            second.BackColor = Style.SelectedCellBgColor;
            first.ForeColor = Style.SelectedCellFgColor;
            second.ForeColor = Style.SelectedCellFgColor;
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

        private Point GetArrayLocation()
        {
            if (Program.InputedArray.Count > 32) return new Point(120, 100);
            if (Program.InputedArray.Count >= 8)
                return new Point(120, 200 - (Style.CellSize.Height+20)/2 * ((Program.InputedArray.Count - 1) / 8));
            return new Point(440 - (Style.CellSize.Width+5)/2 * Program.InputedArray.Count, 200);
        }
    }
}