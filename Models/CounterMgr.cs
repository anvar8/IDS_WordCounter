using _5_2_2019.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using WordCounterAPI.Data;
using WordCounterAPI.Helpers;

namespace _5_2_2019.Models
{
    public class CounterMgr
    {
        private TextFile srcFile;
        private CsvFile outputFile;
        public TextFile SrcFile { get => srcFile; }
        public CsvFile OutputFile { get => outputFile; }
        public CounterMgr()
        {       
            this.srcFile = new TextFile(@"C:\Users\Public\Documents\lorem.txt");
            this.outputFile = new CsvFile(@"C:\Users\Public\Documents\output.csv");
        }
        public CounterMgr(string inputUrl, string outputUrl)
        {
            this.srcFile = new TextFile(inputUrl);
            this.outputFile = new CsvFile(outputUrl);
        }

        public void Count()
        {
            ExtractWords();
            CountWords();
        }
        public void CountWords()
        {
            //creates dictionary <string, int> to store words and their counts
            foreach (var word in this.srcFile.Words)
            {
                if (!this.srcFile.WordCount.ContainsKey(word.ToString().Trim()))
                {
                    this.srcFile.WordCount.Add(word, 1);
                }
                else
                {
                    this.srcFile.WordCount[word] += 1;
                }
            }
            Console.WriteLine(this.srcFile.WordCount);
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

            //note: returns false if file is reached, but permission denied.
            if (!File.Exists(this.srcFile.FileUrl))
            {
                var text = System.IO.File.ReadAllText(this.srcFile.FileUrl);
                //get rid of punctuation
                text = Regex.Replace(text, @"[^\w\s]", "");
                //turn into an array
                this.srcFile.Words = new List<string>(text.Split(" "));

            }
            else
            {
                throw new Exception($"File not found at {this.srcFile.FileUrl}");
            }
        }

        public void SaveCountResult(IFileRepo repo)
        {
            this.SaveCountResultFile(this.srcFile.WordCount);
            this.SaveCountResultDB(this.srcFile.WordCount, repo);
        }
        private void SaveCountResultFile(Dictionary<string, int> resultDict)
        {
            //before your loop
            var csv = new StringBuilder();
            //in your loop
            foreach (KeyValuePair<string, int> entry in resultDict)
            {
                var newLine = string.Format("{0},{1}", entry.Key, entry.Value);
                csv.AppendLine(newLine);
            }
            File.WriteAllText(this.outputFile.FileUrl, csv.ToString());
        }
        private void SaveCountResultDB(Dictionary<string, int> resultDict, IFileRepo repo)
        {
            var record = new FileConversionRecord(this.srcFile, this.outputFile);
            repo.SaveRecord(record);        
        }
    }


}
