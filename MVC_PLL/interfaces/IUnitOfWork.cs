using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeReposatory EmployeeReposatory { get; set; }

        public IdepartmentReposatory DepartmentReposatory { get; set; }

        Task<int> Complete();
        
    }
}
