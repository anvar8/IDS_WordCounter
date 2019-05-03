using WordCounterAPI.Helpers;

namespace WordCounterAPI.Data
{
    public class FileConversionRecord
    {
        public FileConversionRecord()
        {

        }
        public FileConversionRecord(TextFile src, CsvFile dest)
        {
            this.Source = src.FileUrl;
            this.Output = dest.FileUrl;
        }
        public int Id { get; set; }
        public string Source { get; set; }
        public string Output { get; set; }
    }
}