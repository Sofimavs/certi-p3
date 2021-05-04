using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Practica2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IConfiguration _config;
        public StudentsController(IConfiguration config)
        {
            _config = config;

        }
                [HttpGet]
        public List<Student> GetStudent()
        {
            string projectTitle = _config.GetSection("Project").GetSection("Title").Value;
            string dbConnection = _config.GetConnectionString("Database");
            Console.Out.WriteLine($"We are connecting to ... {dbConnection}")
           
            return new List<Student>(){
                new Student(){Name = $"Sofia Vargas from env: {projectTitle}"},
                new Student(){Name = "Andi Guardia"},
                new Student(){Name = "Gabriel Perez"},
                new Student(){Name = "Ale Ledezma"},
            };
        }
       [HttpPost]
        public Student CreateStudent([FromBody] String studentName, String studentLastName)
        {
            return new Student()
            {
                Name = studentName,
            };
        }

        [HttpPut]
        public Student UpdateStudent([FromBody] Student student)
        {
            student.Name = "updated";
            return student;
        }

        [HttpDelete]
        public Student DeleteStudent([FromBody] Student student)
        {
            student.Name = "deleted";
            return student;
        }
    }
}
