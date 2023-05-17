using MVC.BLL.interfaces;
using MVC.DAL.CONTAXT;
using MVC.DAL.models;
using System.Linq;

namespace MVC.BLL.repositories
{
    public class EmployeeReopsatory :GenaricReposatory<Employee>, IEmployeeReposatory
    {
        public EmployeeReopsatory(MVCDbContext dbContext):base(dbContext)
        {
            
        }

        IQueryable<Employee> IEmployeeReposatory.searchEmployeByName(string SearchValue)
            =>_dbContext.Employees.Where(e=>e.Name.ToLower().Contains(SearchValue.ToLower()));
       
    }

}
