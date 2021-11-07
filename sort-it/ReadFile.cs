using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace sort_it
{
    class ReadFile
    {
        public static void Read(string pathOut, string fileIn, ref List<int> sortingList)
        {
            using (FileStream fstream = File.OpenRead(pathOut + fileIn))
            {
                byte[] bytes = new byte[fstream.Length];

                fstream.Read(bytes, 0, bytes.Length);

                string[] words = System.Text.Encoding.UTF8.GetString(bytes).Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < words.Length; ++i)
                {
                    sortingList.Add(Convert.ToInt32(words[i]));
                }
            }
        }

        public static bool Read(string pathOut, string fileIn)
        {
            using (FileStream fstream = File.OpenRead(pathOut + fileIn))
            {
                byte[] bytes = new byte[fstream.Length];

                fstream.Read(bytes, 0, bytes.Length);

                try
                {
                    string textFromFile = new string(Encoding.UTF8.GetString(bytes).Where(c => !char.IsControl(c)).ToArray());

                    if (new Regex(@"\D").IsMatch(textFromFile))
                    {
                        Console.WriteLine($"Файл {fileIn} содержит символы, которе не яляются целыми числами");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    Console.WriteLine("Слишком большой файл, попробуйте другой");

                    return false;
                }
            }
        }
    }
}
