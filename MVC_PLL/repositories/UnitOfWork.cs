using MVC.BLL.interfaces;
using MVC.DAL.CONTAXT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.repositories
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly MVCDbContext _dbContext;

        public IEmployeeReposatory EmployeeReposatory { get; set; }
        public IdepartmentReposatory DepartmentReposatory { get; set; }
        public UnitOfWork(MVCDbContext dbContext)
        {
            EmployeeReposatory= new EmployeeReopsatory(dbContext);
            DepartmentReposatory= new DepartmentReopsatory(dbContext);
            _dbContext = dbContext;
        }

        public async Task< int> Complete() 
            => await _dbContext.SaveChangesAsync();

        public void Dispose() => _dbContext.Dispose();
        
    }
}
