using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01.ADV05
{
    class Department
    {
        public int DeptID { get; set; }
        public string? DeptName { get; set; }
        public List<Employee>? Staff;
        public Department()
        {
            Staff = new List<Employee>();
        }
        public void AddStaff(Employee E)
        {


            Staff?.Add(E);
            Console.WriteLine($"Employee {E.EmployeeID} Added to Department {DeptName}");
            E.EmployeeLayOff += RemoveStaff;

        }
        public void RemoveStaff(object? sender, EmployeeLayOffEventArgs e)
        {
            Employee? emp = sender as Employee;
            if (emp != null)
            {
                if (Staff?.Contains(emp) ?? false)
                {
                    Console.WriteLine($"Employee {emp.EmployeeID} removed from {DeptName}. Cause: {e.Cause}");
                    Staff.Remove(emp);

                }
            }



        }
    }

}
