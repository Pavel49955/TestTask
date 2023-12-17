using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Введите ссылку на фаил в котором будет осуществляться поиск слова");
            var path = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();

            Console.WriteLine("Введите искомое слово");

            string wordForSearch = Console.ReadLine();
            Regex regex = new Regex(wordForSearch + @"(\w*)");
            for (int i = 0; i < files.Length; i++)

            {
                //todo: исправить что бы был вывод названия файла (добавить комментарии для пользователя) 
                Console.WriteLine(File.ReadAllText(files[i].FullName));




                var text1 = File.ReadAllText(files[i].FullName);
                MatchCollection matches = regex.Matches(text1);
                if (matches.Count > 0)
                {
                    Console.WriteLine(matches);
                }
                else
                {
                    Console.WriteLine("Слово не найдено в файле");
                }

            }
            Console.WriteLine("Введите текст который хотите добавить в фаил");
            string text = Console.ReadLine();
            File.WriteAllText("D:\\test\\C#.txt", text);
            Console.ReadLine();
        }
    }
}