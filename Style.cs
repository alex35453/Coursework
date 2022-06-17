using System.Drawing;

namespace Курсова
{
    public static class Style
    {
        public static readonly Font TitleFont = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
        public static readonly Font ButtonFont = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
        public static readonly Font StandardFont = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);

        public static Color ConfirmButtonBgColor = Color.LimeGreen;
        public static Color RemoveButtonBgColor = Color.Crimson;
        public static Color StandardButtonBgColor = Color.White;
        public static Color ActionButtonBgColor = Color.RoyalBlue;
        
        public static Color ConfirmButtonFgColor = Color.White;
        public static Color RemoveButtonFgColor = Color.White;
        public static Color StandardButtonFgColor = Color.Black;
        public static Color ActionButtonFgColor = Color.White;


        public static Color StandardCellBgColor = Color.RoyalBlue;
        public static Color StandardCellFgColor = Color.White;
        public static Color IncorrectOrderedCellBgColor = Color.Red;
        public static Color IncorrectOrderedCellFgColor = Color.White;
        public static Color CorrectOrderedCellBgColor = Color.LimeGreen;
        public static Color CorrectOrderedCellFgColor = Color.White;
        public static Color SelectedCellBgColor = Color.CornflowerBlue;
        public static Color SelectedCellFgColor = Color.White;
        
        public static Size CellSize = new Size(80, 40);
    }
}