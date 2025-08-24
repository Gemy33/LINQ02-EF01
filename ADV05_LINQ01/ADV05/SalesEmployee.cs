using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01.ADV05
{
    internal class SalesEmployee: Employee
    {
        public int AchievedTarget { get; set; }
        public bool CheckTarget(int Quota)
        {
            if (Quota<AchievedTarget)
            {

                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause=LayOffCause.notAchievedTarget});
                return false;
            }
            return true;
        }
        public override int VacationStock { get => 0; set; }
    }
}
