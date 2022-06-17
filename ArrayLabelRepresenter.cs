using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсова
{
    public class ArrayLabelRepresenter : IDisposable
    {
        public Point Location;
        public Size Size;
        public int Count { get; }
        private Form _form;
        private int[] values;
        private Label[] representation;
        
        public ArrayLabelRepresenter(Form form, Point location, Size size)
        {
            this._form = form;
            this.Location = location;
            this.Size = size;
            this.values = Program.InputedArray.ToArray();
            this.Count = values.Length;
            representation = new Label[values.Length+1];
            ResetCellPositions();
        }
        
        public int this[int index] => values[index];

        public (Label, Label) this[int first, int second] => (representation[first], representation[second]);

        public void Swap(int i1, int i2)
        {
            (values[i1], values[i2]) = (values[i2], values[i1]);
            (representation[i1], representation[i2]) = (representation[i2], representation[i1]);
        }

        public void Dispose()
        {
            foreach (Label cell in representation)
            {
                _form.Controls.Remove(cell);
            }
        }

        public void ResetCellPositions(bool hard = true)
        {
            if (hard) this.values = Program.InputedArray.ToArray();
            foreach (Label cell in representation)
            {
                _form.Controls.Remove(cell);
            }

            int i;
            for(i = 0; i < values.Length; i++)
            {
                representation[i] = new Label();
                representation[i].Font = Style.StandardFont;
                representation[i].Text = "" + values[i];
                representation[i].BackColor = Style.StandardCellBgColor;
                representation[i].ForeColor = Style.StandardCellFgColor;
                representation[i].TextAlign = ContentAlignment.MiddleCenter;
                representation[i].Size = Style.CellSize;
                representation[i].Location = new Point(this.Location.X+(i%8)*(Style.CellSize.Width+3), this.Location.Y+(i/8)*(Style.CellSize.Height+20));
                _form.Controls.Add(representation[i]);
            }

            if (i%8 > 0) i+=8;
            _form.Controls.Add(new Label(){Size = new Size(0,0), Location = new Point(this.Location.X+i%8*(Style.CellSize.Width+3), this.Location.Y+i/8*(Style.CellSize.Height+20))});
        }

        public void GetQuickResult()
        {
            Array.Sort(values);
            ResetCellPositions(false);
        }
    }
}