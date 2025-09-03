using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01
{
    internal class ITI01Context:DbContext
    {

        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student_Course> Student_Courses { get; set; }
        public DbSet<Course_Ins> Course_Ins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITI01;Integrated Security=True;Trust Server Certificate=True");
        }
        //Data Source=.;Initial Catalog=ITI;Integrated Security=True;Encrypt=True;Trust Server Certificate=True
    }
}
