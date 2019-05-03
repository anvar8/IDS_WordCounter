
using System.ComponentModel.DataAnnotations.Schema;

namespace WordCounterAPI.Helpers
{
    public class CsvFile : IFile
    {
        public string FileUrl { get; set; }
        public CsvFile(string outputUrl)
        {
           this.FileUrl = outputUrl;
        }

    }
}