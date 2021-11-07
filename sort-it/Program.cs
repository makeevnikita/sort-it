using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sort_it
{
    class Program
    {
        //sortMode - режим сортировки -a(по возрастанию) или -d(по убыванию)
        //fileOut - название выходного файла
        public static string sortMode = "", fileOut = "", pathOut = "";
        static void Main(string[] args)
        {
            sortMode = args[0];
            fileOut = ReadCorrectPath.Read(args[1]);
            pathOut = args[2];

            if (pathOut.Substring(pathOut.Length) != @"\")
            {
                pathOut += @"\";
            }

            if (!SetParameters.Set(args[0], args[1], args[2]))
            {
                Console.WriteLine("Неверные параметры");
                return;
            }

            List<string> fileInList = new List<string>();

            Console.WriteLine("Добавьте хотя бы один файл из директории " + pathOut + " и напишите команду -start, когда готово");

            while (true)
            {
                string read = Console.ReadLine();

                if (read == "-start")
                {
                    if (fileInList.Count() == 0)
                        Console.WriteLine("Добавьте хотя бы два файла");
                    else if (fileInList.Count() == 1)
                        Console.WriteLine("Добавьте ещё хотя бы один файл");
                    else { Console.WriteLine("Выполняю"); break;}
                }
                else
                {
                    read = ReadCorrectPath.Read(read);

                    Console.WriteLine(pathOut);

                    if (File.Exists(pathOut + read))
                    {
                        if (ReadFile.Read(pathOut, read))
                        {
                            fileInList.Add(read);
                            Console.WriteLine("Файл добавлен. Всего файлов - {0}", fileInList.Count());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Файл {read} не существует");
                    }
                }
            }

            List<int> sortingList = new List<int>();

            foreach (var fileIn in fileInList)
            {
                ReadFile.Read(pathOut, fileIn, ref sortingList);
            }

            WriteFile.Write(sortingList, pathOut, fileOut);

            Console.Read();
        }
    }
}
