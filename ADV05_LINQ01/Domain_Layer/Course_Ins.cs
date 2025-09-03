using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01
{
    internal class Course_Ins
    {
        [Key]
        public int Crs_Id { get; set; }
        public int Ins_Id { get; set; }
        public int evelute { get; set; }
    }
}
