using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Курсова
{
    /// <summary>
    /// Клас для читання інформації з файлу
    /// </summary>
    public static class FileReader
    {
        /// <summary>
        /// Функція для зчитування масиву чисел з файлу
        /// </summary>
        /// <param name="filename">шляї до файлу</param>
        /// <returns>список чисел</returns>
        public static List<int> GetContent(string filename)
        {
            string[] content = File.ReadAllText(filename).Split(',');
            List<int> array = new List<int>();
            foreach (string number in content)
            {
                array.Add(Int32.Parse(number));
            }
            return array;
        }

        /// <summary>
        /// Перевірка файлу на валідність - чи існує він і чи можна з нього зчитати числа
        /// </summary>
        /// <param name="filename">шлях до файлу</param>
        /// <returns>false - якщо файлу не існує, він порожній або містить нечислові дані;<br/>
        /// true - якщо дані нас влаштовують</returns>
        public static bool FileIsValid(string filename)
        {
            if (!File.Exists(filename)) return false;
            string content = File.ReadAllText(filename);
            return Regex.IsMatch(content, @"^(?:-?\d+,)*\d+\r?\n?$");    // for example, "5,25,96,15,0,9"
        }
    }
}