using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Курсова
{
    static class Program
    {
		/// <summary>
        /// зберігає масив елементів для використання по всій програмі
        /// </summary>
        public static List<int> InputedArray = new List<int>();

		/// <summary>
        /// Показує, закрили ми форму програмно, ачи це зробив сам користувач. Якщо користувач - інші форма теж має бути закрито. Інакше обробити це як програмне закриття і продовжити роботу минулих/наступних форм
        /// </summary>
        public static bool IsClosedByUser = true;

        /// <summary>
        ///  Вхідна точка програми
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
