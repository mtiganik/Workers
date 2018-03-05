using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Position
    {
        public Position(string inputString)
        {
            this.PositionName = inputString;
        }

        public int PositionId { get; set; }

        public string PositionName { get; set; }
    }
}
