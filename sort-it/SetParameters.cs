using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sort_it
{
    class SetParameters
    {
        public static bool Set(string sortMode, string fileOut, string pathOut)
        {
            if (!Directory.Exists(pathOut))
            {
                Console.WriteLine("Директории " + pathOut + " не существует");
                return false;
            }

            if (!(sortMode == "-a" || sortMode == "-d"))
            {
                Console.WriteLine("Выберите режим сортировки -a(по возрастанию) или -d(по убыванию)");
                return false;
            }

            Regex regex = new Regex(@"[/:*?<>|+\\]");

            if (regex.IsMatch(fileOut))
            {
                Console.WriteLine("Имя файла не может содержать символы /:*?<>|+\\");
                return false;
            }

            return true;
        }
    }
}
