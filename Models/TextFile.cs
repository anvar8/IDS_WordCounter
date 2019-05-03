using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCounterAPI.Helpers
{
    public class TextFile 
    {

        private List<string> words = new List<string>();
        public List<string> Words { get => this.words; set { this.words = value; } }
        private Dictionary<string, int> wordCount = new Dictionary<string, int>();
        public Dictionary<string, int> WordCount { get => this.wordCount; }
        public string FileUrl { get; set; } 
        public TextFile(string fileUrl)
        {
                this.FileUrl = fileUrl;
        }




    }
}