using Microsoft.EntityFrameworkCore;
using MVC.BLL.interfaces;
using MVC.DAL.CONTAXT;
using MVC.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.repositories
{
    public class GenaricReposatory<T> : IGenaricReposatory<T> where T : class
    {
        private protected readonly MVCDbContext _dbContext;

        public GenaricReposatory(MVCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(T item)
            =>await _dbContext.Set<T>().AddAsync(item);
         


        public void Delete(T item)
            =>_dbContext.Set<T>().Remove(item);
        
        public async Task< T> Get(int id)  => 
                await _dbContext.Set<T>().FindAsync(id);




        public async Task<IEnumerable<T>> GetAll()
        {
            if (typeof(T) == typeof(Employee))
                return  (IEnumerable<T>)await _dbContext.Employees.Include(e => e.Department).ToListAsync();
            else
                return await  _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T item)
            => _dbContext.Set<T>().Update(item);
         
    }
}
