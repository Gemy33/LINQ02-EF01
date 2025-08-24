using ADV05_LINQ01.ADV05;

namespace ADV05_LINQ01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region problem01
            var emp1 = new Employee { EmployeeID = 101, BirthDate = new DateTime(1985, 1, 1), VacationStock = 5 };
            var emp2 = new Employee { EmployeeID = 102, BirthDate = new DateTime(1940, 1, 1), VacationStock = 10 };
            var dept = new Department { DeptID = 1, DeptName = "IT" };
            var club = new Club { ClubID = 1, ClubName = "Chess" };
            SalesEmployee emp3 = new SalesEmployee { EmployeeID = 201, BirthDate = new DateTime(1990, 1, 1), VacationStock = 15, AchievedTarget=10 };
            BoardMember boardMember = new BoardMember { EmployeeID = 301, BirthDate = new DateTime(1970, 1, 1), VacationStock = 20 };

            Console.WriteLine("======================= Before fire the trigger ================");
            dept.AddStaff(emp1);
            dept.AddStaff(emp2);
            club.AddMember(emp1);
            club.AddMember(emp2);
          

            Console.WriteLine("======================= AFter fire the trigger ================");
            emp3.CheckTarget(3);
            emp1.VacationStock = -2;



            #endregion
        }
    }
}
