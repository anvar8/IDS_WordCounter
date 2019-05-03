using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCounterAPI.Helpers
{
    public class TextFile : IFile, ICountable
    {

        private List<string> words = new List<string>();
        private Dictionary<string, int> wordCount = new Dictionary<string, int>();
        public string FileUrl { get; set; }
        public Dictionary<string, int> WordCount { get => this.wordCount; }
        public TextFile(string fileUrl)
        {
                this.FileUrl = fileUrl;
        }

        public void Count()
        {
            ExtractWords();
            CountWords();
        }
        public void CountWords()
        {
            foreach (var word in this.words)
            {
                if (!this.wordCount.ContainsKey(word.ToString().Trim()))
                {
                    this.wordCount.Add(word, 1);
                }
                else
                {
                    this.wordCount[word] += 1;
                }
            }
            Console.WriteLine(this.wordCount);
        }

        public void ExtractWords()
        {
            //seed to test
            //string [] ranWords = { "hello", "world", "is", "pretty" };
            //for (var i=0; i< 100; i++)
            //{
            //    var rand = new Random();
            //    var idx = rand.Next(0, ranWords.Length);
            //    this.words.Add(ranWords[idx]);
            //}
            if (!File.Exists(this.FileUrl))
            {
                var text = System.IO.File.ReadAllText(this.FileUrl);
                //get rid of punctuation
                text = Regex.Replace(text, @"[^\w\s]", "");
                this.words = new List<string>(text.Split(" "));

            }
            else
            {
                throw new Exception($"File not found at {this.FileUrl}");
            }
        }



    }
}