using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Practica2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public StudentsController()
        {

        }
                [HttpGet]
        public List<Student> GetStudent()
        {
            return new List<Student>(){
                new Student(){Name = "Sofia Vargas"},
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
