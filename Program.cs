using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
namespace practika_16
{
    class Program
    {
        static void PrintBefore(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '/')
                {
                    Console.Write($"{text[i]} ");
                }
                else
                {
                    break;
                }
            }
        }
        static void PrintCount(string count, Dictionary<string, int> dic)
        {
            if (count != "" & CheckNumber(count))
            {
                int n = Convert.ToInt32(count);
                var sorted_count = dic.Values.SkipWhile(x => x < n).ToList();
                for (int i = 0; i < sorted_count.Count; i++)
                {
                    Console.WriteLine(sorted_count[i]);
                }
            }
            else
            {
                Console.WriteLine("Не верное значение");
            }
        }
        static void PrintCountry(Dictionary<string, int> dic)
        {
            var dic2 = dic.Keys.OrderBy(x => x).ToList();
            for (int i = 0; i < dic2.Count; i++)
            {
                Console.WriteLine(dic2[i]);
            }
        }
        static int CountNumber(string text)
        {
            char[] str = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                str[i] = text[i];
            }
            var Count = str.Where(x => char.IsNumber(x));
            return Count.Count();
        }
        static bool CheckNumber(string num)
        {
            if (double.TryParse(num, out var result) || int.TryParse(num, out var result2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void PrintAfter(string text)
        {
            int start = text.IndexOf('/') + 1;
            char[] txt = new char[text.Length];
            int count = 0;
            for (int i = start; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    txt[count] = char.ToLower(text[i]);
                    Console.Write($"{char.ToLower(text[i])} ");
                    count++;
                }
                else
                {
                    txt[count] = char.ToUpper(text[i]);
                    Console.Write($"{char.ToUpper(text[i])} ");
                    count++;
                }
            }
            StreamWriter sw = File.CreateText("2В.txt");
            for (int i = 0; i < txt.Length; i++)
            {
                sw.Write($"{txt[i]} ");
            }
            sw.Close();
        }
        public static void zadanie1()
        {
            try
            {
                StreamReader sr = File.OpenText("1.txt");
                string str = sr.ReadToEnd().ToLower();
                if (File.Exists("1.txt"))
                {
                    string[] array = str.Split(new string[] { " ", ".", ",", "?", "!", "|", ":" }, StringSplitOptions.RemoveEmptyEntries);
                    Console.WriteLine("Введите слово: ");
                    string word = Console.ReadLine();
                    if (word == "" || word == " ")
                    {
                        Console.WriteLine("Введите слово!");
                    }
                    else
                    {
                        var count = array.Where(x => x == word);
                        Console.WriteLine($"Были найдены {count.Count()} вхождения (ий) поискового запроса {word}");
                    }
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("Файл не найден!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }
        }
        public static void zadanie2А()
        {
            Console.WriteLine("Введите предложение: ");
            string InpuntStr = "";
            InpuntStr = Console.ReadLine();
            char[] str = new char[InpuntStr.Length];
            for (int i = 0; i < InpuntStr.Length; i++)
            {
                str[i] = InpuntStr[i];
            }
            var Count = str.Where(x => char.IsNumber(x));
            Console.WriteLine("Кол-во цифр " + Count.Count());
        }
        public static void zadanie2Б()
        {
            Console.WriteLine("Введите предложение: "); 
            string InpuntStr = "";
            if (InpuntStr != "" || InpuntStr != " ")
            {
                try
                {
                    InpuntStr = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Неверный ввод");
                }
                foreach (var s in InpuntStr)
                {
                    if (s == '/')
                        break;
                    Console.Write(s);
                }
            }
            else
            {
                Console.WriteLine("Введите продложение!");
            }
        }
        public static void zadanie2В(string text)
        {
            int start = text.IndexOf('/') + 1;
            char[] txt = new char[text.Length];
            int count = 0;
            for (int i = start; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                {
                    txt[count] = char.ToLower(text[i]);
                    Console.Write($"{char.ToLower(text[i])} ");
                    count++;
                }
                else
                {
                    txt[count] = char.ToUpper(text[i]);
                    Console.Write($"{char.ToUpper(text[i])} ");
                    count++;
                }
            }
            StreamWriter sw = File.CreateText("2В.txt");
            for (int i = 0; i < txt.Length; i++)
            {
                sw.Write($"{txt[i]} ");
            }
            sw.Close();
        }
        public static void zadanie3()
        {
            double[] MainArr = new double[8] { 2.5, 7, 4, 2.5, 1, 4, 8.1, 4 };
            int[] ch = new int[8]; 
            List<double> list = new List<double>();
            for (int i = 0; i < 8; i++)
            {
                int e = 0;
                int count = 0;
                for (int j = 0; j < 8; j++)
                {
                    if (MainArr[i] == MainArr[j]) count++;

                    e++;
                }
                if (e != 1) ch[i] = count;
            }
            for (int i = 0; i < 8; i++)
            {
                if (!list.Contains(MainArr[i]))
                Console.WriteLine(MainArr[i] + " - " + ch[i]);
                list.Add(MainArr[i]);
            }
        }
        public static void zadanie4()
        {
            if (File.Exists("country.txt"))
            {
                StreamReader sr = File.OpenText("country.txt");
                Dictionary<string, int> country = new Dictionary<string, int>();
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    if (temp != "" || temp != " ")
                    {
                        string[] txt = temp.Split(' ');
                        if (CheckNumber(txt[1]))
                        {
                            country.Add(txt[0], Convert.ToInt32(txt[1]));
                        }
                        else
                        {
                            Console.WriteLine("В файле не верное значение!");
                        }
                    }
                }
                PrintCountry(country);
                sr.Close();

                Console.WriteLine();
                Console.WriteLine("Введите численость: ");
                string count = Console.ReadLine();
                PrintCount(count, country);
            }
            else
            {
                Console.WriteLine("Файл не найден!");
            }
        }
        static void Main(string[] args)
        {
            //zadanie1();
            //zadanie2А();
            //zadanie2Б();
            /*zadanie2В("");
            Console.WriteLine("Введите предложение ");
            string text2 = Console.ReadLine();
            if (text2.Contains("/"))
            {
                Console.WriteLine($"Количество цифр: {CountNumber(text2)}");
                Console.WriteLine();
                PrintBefore(text2);
                Console.WriteLine();
                PrintAfter(text2);
            }
            else
            {
                Console.WriteLine("Текст должен содержать символ /");
            }*/
            //zadanie3();
            //zadanie4();
        }
    }
}
