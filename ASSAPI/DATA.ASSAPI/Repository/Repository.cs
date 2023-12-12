using DATA.ASSAPI.DBContext;
using DATA.ASSAPI.Models;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KeenCleaner.Service.RepositoryPattern
{
    public class Repository<T> : IRepository<T> where T : class
    {
        #region property  
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> entities;
        private readonly IConfiguration iconfiguration;
        #endregion

        #region Constructor  
        public Repository(ApplicationDbContext applicationDbContext, IConfiguration iconfiguration)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
            this.iconfiguration = iconfiguration;
        }
        #endregion

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public T Get(string Id)
        {
            return entities.SingleOrDefault(c => c.ToString() == Id.ToString());
        }

        public async Task<T> GetAsync(Guid Id)
        {
            return await entities.FirstOrDefaultAsync(c => c.ToString() == Id.ToString());
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            _applicationDbContext.SaveChanges();
            return entity;
        }
        public async Task<T> InsertAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public async Task<T> RemoveAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _applicationDbContext.SaveChangesAsync();
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            _applicationDbContext.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
            return entity;
        }

        public IEnumerable<T> FindAll(Func<T, bool> exp)
        {
            return entities.Where<T>(exp);
        }

        public T GetByName(string name)
        {
            return entities.FirstOrDefault(c => c.ToString() == name.ToString());
        }

        public T GetById(Func<T, bool> exp)
        {
            return entities.FirstOrDefault(exp);
        }

        public async Task<T> GetByIdAsync(Func<T, bool> exp)
        {
            return await entities.FirstOrDefaultAsync();
        }

        public T GetDataObjectByParamater(Func<T, bool> exp)
        {
            return entities.FirstOrDefault(exp);
        }

        //-----------DBSet for tables to get accessed through the repository
        public DbSet<Product> Products => _applicationDbContext.Products;
       
    }
}
