using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Worker
    {
        public int WorkerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime ContractFrom { get; set; }

        [DataType(DataType.Date)]
        public DateTime ContractUntil { get; set; }

        public ContractType WorkerContractType {get; set;}

        public Department WorkerDepartment { get; set; }

        public Position WorkerPosition { get; set; }

        public string ContractUntilToString(string input)
        {
                if (ContractUntil.Year == 0001)
                {
                    return "-";
                }
                else return ContractUntil.ToString(input);
        }
    }
}
