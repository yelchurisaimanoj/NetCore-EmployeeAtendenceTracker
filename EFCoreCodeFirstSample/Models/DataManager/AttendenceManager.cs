using EFCoreCodeFirstSample.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class AttendenceManager : IAttenedenceRepository
    {
        readonly EmployeeContext _employeeContext;
        public AttendenceManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public void Add(Attendence entity)
        {
            _employeeContext.AttendenceLogs.Add(entity);
            _employeeContext.SaveChanges();
        }

        public IEnumerable<Attendence> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetLogsByEmployee(int employeeID)
        {
            var attendences = _employeeContext.AttendenceLogs.Where(x => x.EmployeeID == employeeID).ToList();

            var activities = attendences.GroupBy(x => x.LogDate.ToString("dd/M/yyyy")).Select(y =>
             {
                 return new Activity { EmployeeID = y.FirstOrDefault().EmployeeID, LoginDateTime = y.Min().LogDate, LogOffDateTime = y.Max().LogDate, ActiveHours = (y.Max().LogDate - y.Min().LogDate).TotalHours };

             });
            return activities;
        }
    }
}

