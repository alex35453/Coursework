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
            representation = new Label[values.Length];
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
            
            for(int i = 0; i < representation.Length; i++)
            {
                representation[i] = new Label();
                representation[i].Font = Style.StandardFont;
                representation[i].Text = "" + values[i];
                representation[i].BackColor = Style.StandardCellBgColor;
                representation[i].ForeColor = Style.StandardCellFgColor;
                representation[i].TextAlign = ContentAlignment.MiddleCenter;
                representation[i].Size = Style.CellSize;
                representation[i].Location = new Point(this.Location.X+i*Style.CellSize.Width, this.Location.Y);
                _form.Controls.Add(representation[i]);
            }
        }

        public void GetQuickResult()
        {
            Array.Sort(values);
            ResetCellPositions(false);
        }
    }
}