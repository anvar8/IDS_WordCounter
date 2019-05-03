using _5_2_2019.Data;
using Microsoft.EntityFrameworkCore;

namespace WordCounterAPI.Data
{
    public class FileRepo : IFileRepo
    {
        private readonly DataContext context;
        public FileRepo(DataContext ctxt)
        {
            this.context = ctxt;
        }
        public DbSet<FileConversionRecord> GetRecords()
        {

            return context.conversionRecords;

        }
        public void SaveRecord(FileConversionRecord record)
        {
            context.conversionRecords.Add(record);
            context.SaveChanges();

        }
    }
}