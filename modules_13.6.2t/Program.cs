using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace modules_13._6._2t
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
                var path = @"C:\Users\Fed_w\Downloads\Text1.txt";
                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                string[] fileWord = ReadFile(path);
                AddToDictionary(fileWord, dictionary);
                PrintSortedDictionary(dictionary);


        }
        static void PrintSortedDictionary(Dictionary<string, int> dictionary)
        {
            var sortedWordCounts = dictionary.OrderByDescending(pair => pair.Value);
            int countFor = 0;
            foreach (var pair in sortedWordCounts)
            {
                if (countFor == 10) break;
                countFor++;
                Console.WriteLine($"Слово ({pair.Key}) встречается {pair.Value} раз");
            }
        }
        static void AddToDictionary(string[] fileWord, Dictionary<string, int> dictionary)
        {
            foreach (var word in fileWord)
            {

                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary[word] = 1;
            }
           
        }
       static string[] ReadFile(string path)
        {
            string textFile = "";
            using (StreamReader sr = new StreamReader(path))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    textFile += str;
            }
            string[] fileWord = textFile.Split(new[] { ' ', '.', ',', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(word => word.ToLower())
                                      .ToArray();
            return fileWord;
        }
    }
}
