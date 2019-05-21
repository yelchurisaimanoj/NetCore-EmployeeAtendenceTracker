using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IAttenedenceRepository
    {
        IEnumerable<Attendence> GetAll();
        void Add(Attendence entity);

        IEnumerable<Activity> GetLogsByEmployee(int employeeID);

    }
}
