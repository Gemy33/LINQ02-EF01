using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01.ADV05
{
    class Club
    {
        public int ClubID { get; set; }
        public String? ClubName { get; set; }
        List<Employee> Members;
        public Club()
        {
            Members = new List<Employee>();
        }
        public void AddMember(Employee E)
        {
            Members.Add(E);
            Console.WriteLine($"Employee {E.EmployeeID} Added to {ClubName}.");

            E.EmployeeLayOff += RemoveMember;
            ///Try Register for EmployeeLayOff Event Here 
        }
        ///CallBackMethod 
        public void RemoveMember(object? sender, EmployeeLayOffEventArgs e)
        {

            Employee? emp = sender as Employee;
            if (emp is not null && Members.Contains(emp))
            {
                if (emp.VacationStock < 0)
                {
                    Console.WriteLine($"Employee {emp.EmployeeID} removed from {ClubName}. Cause: {e.Cause}");

                    Members.Remove(emp);

                }
            }
            ///Employee Will not be removed from the Club if Age>60 
            ///Employee will be removed from Club if Vacation Stock < 0 
        }
    }
}
