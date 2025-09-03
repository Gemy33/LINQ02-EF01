using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01
{
    internal class Course
    {
        [Key]
        public int Curs_id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public int Top_id { get; set; }
   
    }
}
