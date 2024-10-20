using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW14
{
    
    public class ParallelArrayTasks
    {
        private int[] array;
        private string text;

        public ParallelArrayTasks(int[] array, string text)
        {
            this.array = array;
            this.text = text;
        }

        // Мінімум в масиві
        public Task<int> FindMinAsync()
        {
            return Task.Run(() => array.Min());
        }

        // Максимум в масиві
        public Task<int> FindMaxAsync()
        {
            return Task.Run(() => array.Max());
        }

        // Сума елементів масиву
        public Task<int> FindSumAsync()
        {
            return Task.Run(() => array.Sum());
        }

        // Середнє значення в масиві
        public Task<double> FindAverageAsync()
        {
            return Task.Run(() => array.Average());
        }

        // Копіювання частини масиву
        public Task<int[]> CopyArrayPartAsync(int startIndex, int length)
        {
            return Task.Run(() => array.Skip(startIndex).Take(length).ToArray());
        }

        // Частотний словник символів у тексті
        public Task<Dictionary<char, int>> BuildCharFrequencyDictionaryAsync()
        {
            return Task.Run(() =>
            {
                Dictionary<char, int> charFreq = new Dictionary<char, int>();
                foreach (char c in text)
                {
                    if (char.IsLetterOrDigit(c))
                    {
                        if (charFreq.ContainsKey(c))
                        {
                            charFreq[c]++;
                        }
                        else
                        {
                            charFreq[c] = 1;
                        }
                    }
                }
                return charFreq;
            });
        }

        // Частотний словник слів у тексті
        public Task<Dictionary<string, int>> BuildWordFrequencyDictionaryAsync()
        {
            return Task.Run(() =>
            {
                Dictionary<string, int> wordFreq = new Dictionary<string, int>();
                string[] words = text.Split(new[] { ' ', '\n', '\r', '\t', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    string lowerWord = word.ToLower();
                    if (wordFreq.ContainsKey(lowerWord))
                    {
                        wordFreq[lowerWord]++;
                    }
                    else
                    {
                        wordFreq[lowerWord] = 1;
                    }
                }
                return wordFreq;
            });
        }
    }
}

