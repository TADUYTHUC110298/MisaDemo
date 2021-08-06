using System;
using System.Collections.Generic;

namespace MISA.CukCuk.Models
{
    public partial class Position
    {
        public Position()
        {
            Employee = new HashSet<Employee>();
        }

        public Guid PositionId { get; set; }
        public string PositionName { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
