using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01
{
    internal class Student_Course
    {
        [Key]
        public int St_Id { get; set; }
        public int Crs_Id { get; set; }
        public int Grade { get; set; }
    }
}
