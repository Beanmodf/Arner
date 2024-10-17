using Arner.DataAccess;
using Arner.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Arner.Service
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ArnerDbContext _context;
        protected DbSet<T> values;
        public Repository(ArnerDbContext context) 
        {
            _context = context;
            values = context.Set<T>();   
        }
        public async Task<T> Add(T entity)
        {
            await values.AddAsync(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public Task<T> Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await values.ToListAsync();
        }

        public Task<T> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
