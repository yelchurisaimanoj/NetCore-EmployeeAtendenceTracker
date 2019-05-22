using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class AttendenceViewModel
    {

        public int ID { get; set; }

        public int EmployeeID { get; set; }
        public DateTime LogDate { get; set; }
        public bool IsLogin { get; set; }
    }
}