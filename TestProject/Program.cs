using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection.Emit;
using System.Diagnostics.Contracts;
using System.Collections.Generic;
using System.Timers;
using System.Transactions;


namespace TestProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            var result = "";
            //string path5 = @"D:\\save\\DSA.txt";
            Console.WriteLine("Введите путь к фаил в котором будет осуществляться поиск слова.");
            var path = Console.ReadLine();
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            Console.WriteLine("Введите слово для осуществелния поиска повторов.");
            var wordForSearch = Console.ReadLine();
            Regex regex = new Regex(wordForSearch);
            foreach (FileInfo file  in files)
            {

                string text = File.ReadAllText(file.FullName);
                MatchCollection match = regex.Matches(text);
                if (match.Count > 0)
                {
                    var carentResult = $"В фаиле {file.Name} найдено: {match.Count} совпадений.";
                    result = result + carentResult;
                    Console.WriteLine(carentResult);
                }
            }
            Console.WriteLine("Если хотите сохранить фаил в текстовый документ напишите yes:");
            var answer = Console.ReadLine();
            if (answer == "yes")
            {
                Console.WriteLine("Введите путь к файлу в который будет сохранен результат:");
                string pathSave = Console.ReadLine();
                Console.WriteLine("Результат сохранен.");
                
                File.WriteAllText(pathSave, result);
            }
            else 
            {
                Console.WriteLine("Ваш ответ не будет сохранен в фаил.");
            }






            Console.ReadLine();
            
        }

        
    }   
}
