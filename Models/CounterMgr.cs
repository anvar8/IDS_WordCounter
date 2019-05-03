using _5_2_2019.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.srcFile.Count();
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
