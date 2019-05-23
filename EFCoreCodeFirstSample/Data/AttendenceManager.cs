using EFCoreCodeFirstSample.Entities;
using EFCoreCodeFirstSample.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Data
{
    public class AttendenceManager : IDataRepository<Attendence>
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

        public IEnumerable<Attendence> GetListByID(long ID)
        {
            return _employeeContext.AttendenceLogs.Where(x => x.EmployeeID == ID).ToList();
        }

        public Attendence Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attendence> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Attendence employee, Attendence entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Attendence employee)
        {
            throw new NotImplementedException();
        }


    }
}

