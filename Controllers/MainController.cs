using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5_2_2019.Data;
using _5_2_2019.Models;
using Microsoft.AspNetCore.Mvc;
using WordCounterAPI.Data;
using WordCounterAPI.Helpers;

namespace _5_2_2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private CounterMgr mgr;
        private readonly IFileRepo repo;
        public MainController(IFileRepo repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        public dynamic CountWords(string fileUrl)
        {
           //pass input and output urls
            mgr = new CounterMgr();
            if (!string.IsNullOrEmpty(mgr.SrcFile.FileUrl))
            {
                try
                {
                    //extract words and count number of words
                    mgr.Count();
                } 
                catch (Exception e)
                {
                    return e.Message;
                }

                if (mgr.SrcFile.WordCount.Count > 0)
                {
                    //save csv on computer (for testing) and database
                    try
                    {
                        mgr.SaveCountResult(repo);
                        return Newtonsoft.Json.JsonConvert.SerializeObject(mgr.SrcFile.WordCount);
                    }
                    catch (Exception e)
                    {
                        return e.Message;
                    }
           
                }
            }
            //new xception("No file found");
            return $"no file found at {fileUrl}";
        }
    }
}
