using DATA.ASSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KeenCleaner.Service.RepositoryPattern
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();        
        T Get(string Id);
        Task<T> GetAsync(Guid Id);
        Task<T> InsertAsync(T entity);
        T Insert(T entity);
        Task<T> UpdateAsync(T entity);
        T Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        Task<T> RemoveAsync(T entity);
        void SaveChanges();
        IEnumerable<T> FindAll(Func<T, bool> exp);
        T GetByName(string name);
        T GetById(Func<T, bool> exp);
        Task<T> GetByIdAsync(Func<T, bool> exp);
        T GetDataObjectByParamater(Func<T, bool> exp);

        //-----------DBSet for tables to get accessed through the repository
        public DbSet<Product> Products { get; }
      
    }
}
