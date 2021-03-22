using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Domain
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> Query();
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        int Count();
    }
}
