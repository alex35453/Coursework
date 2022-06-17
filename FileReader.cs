using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Курсова
{
    public static class FileReader
    {
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

        public static bool FileIsValid(string filename)
        {
            if (!File.Exists(filename)) return false;
            string content = File.ReadAllText(filename);
            return Regex.IsMatch(content, @"^(?:-?\d+,)*\d+\r?\n?$");    // for example, "5,25,96,15,0,9"
        }
    }
}