using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADV05_LINQ01.ADV05
{
    internal class BoardMember:Employee
    {
        public void Resign()
        {
            OnEmployeeLayOff(new EmployeeLayOffEventArgs { Cause = LayOffCause.resignation });
        }
        public override int VacationStock { get => 0; set; }
        public override DateTime BirthDate { get => base.BirthDate; set => base.BirthDate = value; }
    }
}
