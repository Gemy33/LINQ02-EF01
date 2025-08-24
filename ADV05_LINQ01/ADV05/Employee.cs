using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01.ADV05
{
    class Employee
    {
        public int EmployeeID { get; set; }
      
        private DateTime birthDate;
        public virtual DateTime BirthDate
        {
            get { return birthDate; }
            set
            { 
                birthDate = value;
                if ((DateTime.Now.Year - value.Year) > 60)
                {
                    Console.WriteLine($"NEW Birth date For {EmployeeID} : {value.Year}");
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.ageLimitExceeded }); // implement cause enum
                }

            }
        }

        private int vacationStock;
        public virtual int VacationStock
        {
            get { return vacationStock; }
            set { 
                vacationStock = value;
                if (value < 0 )
                {
                    Console.WriteLine($"NEW Vacation stock for {EmployeeID} : {value}");
                    OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.vacationStockExceeded }); // implement cause enum
                }
            }
        }

        public bool RequestVacation(DateTime From, DateTime To)
        {

            int daysRequested = (To - From).Days;
            if (daysRequested <= VacationStock)
            {
                VacationStock -= daysRequested;

                return true;
            }
            return false;
        }

        public void EndOfYearOperation()
        {

            VacationStock +=10;
            Console.WriteLine($"the vacation stock increased 10 Days is become {VacationStock}");

            if ((DateTime.Now.Year - BirthDate.Year) > 60)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.ageLimitExceeded });
            }

            if (VacationStock < 0)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.vacationStockExceeded });
            }



        }



        public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;
        protected  virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
        {
            Console.WriteLine($"Employee {EmployeeID} Laid of. Cause: {e.Cause}");
            EmployeeLayOff?.Invoke(this, e);
        }
    }
    public enum LayOffCause
    {
        vacationStockExceeded,
        ageLimitExceeded,
        resignation,
        notAchievedTarget
    }
    public class EmployeeLayOffEventArgs
    {
        public LayOffCause Cause { get; set; }
    }

}
