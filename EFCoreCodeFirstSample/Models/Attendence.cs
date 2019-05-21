using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreCodeFirstSample.Models
{
    public class Attendence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }
        public DateTime LogDate { get; set; }
        public bool IsLogin { get; set; }
    }
}