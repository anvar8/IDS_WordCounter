using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordCounterAPI.Data;

namespace _5_2_2019.Data
{
    public interface IFileRepo
    {
         DbSet<FileConversionRecord> GetRecords();

         void SaveRecord(FileConversionRecord record);
       
    }
}
