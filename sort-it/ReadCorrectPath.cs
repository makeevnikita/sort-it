using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_it
{
    //Метод который проверяет формат файла .txt
    class ReadCorrectPath
    {
        public static string Read(string file)
        {
            if (file.Length > 4)
            {
                if (file.Substring(file.Length - 4, 4) != ".txt")
                {
                    file += ".txt";
                }
            }
            else
            {
                file += ".txt";
            }

            return file;
        }
    }
}
