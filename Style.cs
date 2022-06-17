using System.Drawing;

namespace Курсова
{
    public static class Style
    {
        public static readonly Font TitleFont = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly Font ButtonFont = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly Font StandardFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

        public static Color ConfirmButtonBgColor = Color.MediumSeaGreen;
        public static Color RemoveButtonBgColor = Color.Crimson;
        public static Color StandardButtonBgColor = Color.White;
        public static Color ActionButtonBgColor = Color.RoyalBlue;
        
        public static Color ConfirmButtonFgColor = Color.White;
        public static Color RemoveButtonFgColor = Color.White;
        public static Color StandardButtonFgColor = Color.Black;
        public static Color ActionButtonFgColor = Color.White;


        public static Color StandardCellBgColor = Color.White;
        public static Color StandardCellFgColor = Color.Black;
        public static Color IncorrectOrderedCellBgColor = Color.Red;
        public static Color IncorrectOrderedCellFgColor = Color.White;
        public static Color CorrectOrderedCellBgColor = Color.Green;
        public static Color CorrectOrderedCellFgColor = Color.White;

        public static Size CellSize = new Size(80, 40);

    }
}