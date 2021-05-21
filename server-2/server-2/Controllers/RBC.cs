using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace server_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CBR : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "OK";
        }
        [HttpPost]
        public string Post(CBRCurrency cbr)
        {
            fileFactory(cbr.data);

            return "ok";
        }

        [NonAction]
        void fileFactory(string cbrcurr)
        {
            FileStream fStream = new FileStream("Text.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sWriter = new StreamWriter(fStream);
            sWriter.WriteLine(cbrcurr);
            sWriter.Close();
            fStream.Close();
        }

        public class CBRCurrency
        {
            public string data { get; set; }
        }
    }
}
