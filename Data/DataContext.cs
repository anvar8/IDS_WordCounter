using Microsoft.EntityFrameworkCore;
using WordCounterAPI.Data;
using WordCounterAPI.Helpers;

namespace _5_2_2019.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>  options) : base (options) {}
        public DbSet<FileConversionRecord> conversionRecords{get; set;}
       
    }
}