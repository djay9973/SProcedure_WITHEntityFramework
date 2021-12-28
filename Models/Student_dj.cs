using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SProcedure_WITHEntityFramework.Models
{
    public class Student_dj
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; } 
        public int Age { get; set; }
    }
}
