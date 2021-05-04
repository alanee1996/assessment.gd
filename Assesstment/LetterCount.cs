using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assesstment
{
    public class LetterCount
    {
        public void start()
        {
        begin:;
            Console.WriteLine("Please etner the words :");
            string text = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Please make sure you enter some words");
                goto begin;
            }
            Console.WriteLine(letterCounting(text));
        }

        private string letterCounting(string text)
        {
            //remove special characters
            text = Regex.Replace(text, "[^a-zA-z ]", "");
            //words container
            List<string> words = text.Split(" ").ToList();
            //final result which holding the potential value
            Dictionary<string, int> result = new Dictionary<string, int>();
            words.ForEach(word =>
            {
                //character counter
                Dictionary<char, int> record = new Dictionary<char, int>();
                foreach (var c in word)
                {
                    if (record.ContainsKey(c))
                    {
                        record[c] += 1;
                    }
                    else
                    {
                        record.Add(c, 1);
                    }
                }
                record = record.Where(c => c.Value > 1).ToDictionary(k => k.Key, v => v.Value);
                if (record.Count > 0) result.Add(word, record.Sum(c => c.Value));
            });
            if (result.Count == 0) return "-1";
            var final = result.Max(c => c.Value);
            //return the first large value if have two
            return result.FirstOrDefault(c => c.Value == final).Key;
        }
    }
}
