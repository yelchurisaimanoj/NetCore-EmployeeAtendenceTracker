using System.Collections.Generic;
using EFCoreCodeFirstSample.Entities;

namespace EFCoreCodeFirstSample.Data
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        void Add(TEntity entity);
        void Update(TEntity employee, TEntity entity);
        void Delete(TEntity employee);

        IEnumerable<TEntity> GetListByID(long ID);




    }
}
