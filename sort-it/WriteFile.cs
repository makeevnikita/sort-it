using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_it
{
    class WriteFile
    {
        public static void Write(List<int> sortingList, string pathOut, string fileOut)
        {
            using (FileStream fstream = new FileStream(pathOut + fileOut, FileMode.OpenOrCreate))
            {
                byte[] input = Encoding.UTF8.GetBytes(string.Join("\n", Sort.MergeSort(sortingList.ToArray())));

                string[] array = Encoding.UTF8.GetString(input).Split('\n');

                if (Program.sortMode == "-d")
                {
                    Array.Reverse(array);
                }

                input = Encoding.UTF8.GetBytes(string.Join("\n", array));

                fstream.Write(input, 0, input.Length);
                Console.WriteLine($"Текст записан в файл {fileOut} в директории {pathOut}");
            }
        }
    }
}
