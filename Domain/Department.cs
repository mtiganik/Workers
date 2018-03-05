using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Department
    {
        public Department(string inputString)
        {
            this.DepartmentName = inputString;
        }

        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public virtual List<Position> Positions { get; set; } = new List<Position>();
    }
}
