using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practica3.Controllers
{
    [ApiController]
    [Route("/api/info")]
    public class InfoController
    {
        private readonly IConfiguration _config;
        public InfoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public string[] GetInfo()
        {
            string[] info = new string[2];

            info[0] = _config.GetSection("Project").GetSection("Title").Value;
            info[1] = _config.GetConnectionString("Database");
            Console.Out.WriteLine("Connection string");
            return info;



        }
    }
}
