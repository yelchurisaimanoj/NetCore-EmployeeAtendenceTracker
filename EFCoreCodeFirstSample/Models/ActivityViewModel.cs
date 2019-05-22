using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models
{
    public class ActivityViewModel
    {
        public int EmployeeID { get; set; }
        public double ActiveHours { get; set; }

        public DateTime LoginDateTime { get; set; }

        public DateTime LogOffDateTime { get; set; }

    }
}
