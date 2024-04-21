using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryLogic
{
    public class Logic
    {
        public string GenerationText { get; set; }

        List<TextDictionary> text1 { get; set; }

        public Logic()
        {
            text1 = new List<TextDictionary>();
        }

        public string[] GetPhrase()
        {
            string path1 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\1.txt";
            var srcEncodding1 = Encoding.GetEncoding("windows-1251");
            using (StreamReader reader = new StreamReader(path1, encoding: srcEncodding1))
            {
                text1.Add(new TextDictionary { Text = reader.ReadToEnd(), Number = 1 });
            }

            string path2 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\2.txt";
            using (StreamReader reader = new StreamReader(path2, encoding: srcEncodding1))
            {
                text1.Add(new TextDictionary { Text = reader.ReadToEnd(), Number = 2 });
            }

            string path3 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\3.txt";
            using (StreamReader reader = new StreamReader(path3, encoding: srcEncodding1))
            {
                text1.Add(new TextDictionary { Text = reader.ReadToEnd(), Number = 3 });
            }

            string path4 = @"C:\Users\User\OneDrive\Рабочий стол\project 1\Laboratornaya 2.4\File\4.txt";
            using (StreamReader reader = new StreamReader(path4, encoding: srcEncodding1))
            {
                text1.Add(new TextDictionary { Text = reader.ReadToEnd(), Number = 4 });
            }

            string[] Text = new string[text1.Count];
            int index = 0;
            foreach (var text in text1)
            {
                Text[index] = text.Text;
                index++;
            }
            return Text;
        }

        public string GenerateText(int count, bool check, string registr)
        {
            string[] phrase = GetPhrase();

            if (count > 0 && !check)
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < phrase.Length; j++)
                    {
                        if (j != 3)
                        {
                            GenerationText += phrase[j].Split('\n')[i] + " ";
                        }
                        if (j == 3)
                        {
                            GenerationText += phrase[j].Split('\n')[i] + ". ";
                        }
                    }
                }
            }
            else if (count > 0 && check)
            {
                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    int index = random.Next(0, phrase.Length);
                    for (int j = index; j < phrase.Length; j++)
                    {
                        int randomIndex = random.Next(phrase[j].Split('\n').Length);
                        if (j != phrase.Length - 1)
                        {
                            GenerationText += phrase[j].Split('\n')[randomIndex] + " ";
                        }
                        if (j == phrase.Length - 1)
                        {
                            GenerationText += phrase[j].Split('\n')[randomIndex] + ". ";
                        }
                    }
                }
            }

            if (registr == "Нижний регистр")
            {
                GenerationText = GenerationText.ToLower();
            }
            else if (registr == "Верхний регистр")
            {
                GenerationText = GenerationText.ToUpper();
            }
            else if (registr == "Заглавная буква первого слова каждого предложения")
            {
                string str = "";
                str += GenerationText[0].ToString().ToUpper();
                for (int i = 1; i < GenerationText.Length; i++)
                {
                    if (char.IsLetter(GenerationText[i]) && char.IsWhiteSpace(GenerationText[i - 1]) && "!".IndexOf(GenerationText[i - 2]) != -1)
                    {
                        str += GenerationText[i].ToString().ToUpper();
                    }
                    else
                    {
                        str += GenerationText[i].ToString();
                    }
                }
                GenerationText = str;
            }
            return GenerationText;
        }

        public string NumberOfSymbols()
        {
            int Length = GenerationText.Length;
            return Length.ToString();
        }

        public string NumberOfWords()
        {
            char[] symbols = { ' ', ',', '.', '!', '?', '(', ')' };
            string[] symbolsOfWords = GenerationText.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            int number = symbolsOfWords.Length;
            return number.ToString();
        }

        public string NumberOfUniqueWords()
        {
            int count = 0;
            char[] symbols = { ' ', ',', '.', '!', '?', '(', ')' };
            string[] symbolsOfWords = GenerationText.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word1 in symbolsOfWords) 
            {
                foreach (string word2 in symbolsOfWords)
                {
                    if (word1.ToLower() == word2.ToLower())
                    {
                        count++;
                    }
                }
            }
            int k = count - symbolsOfWords.Length;
            return k.ToString();
        }

        public IDictionary<string, int> FrequentWords()
        {
            char[] symbols = { ' ', ',', '.', '!', '?', '(', ')' };
            string[] symbolsOfWords = GenerationText.Split(symbols, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (string word in symbolsOfWords)
            {
                if (!words.ContainsKey(word))
                {
                    words.Add(word, 1);
                }
                else
                {
                    words[word] += 1;
                }
            }
            Dictionary<string, int> words2 = new Dictionary<string, int>();
            int k = 0;
            foreach (var item in words.OrderByDescending(x => x.Value))
            {
                if (k != 5)
                {
                    if (!words2.ContainsKey(item.Key))
                    {
                        words2.Add(item.Key, item.Value);
                    }
                    k++;
                }
            }
            return words2;
        }
    }
}
