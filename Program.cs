using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курсова
{
    static class Program
    {
        public static List<int> InputedArray = new List<int>();
        public static bool IsClosedByUser = true;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InputForm());
        }
    }
}
