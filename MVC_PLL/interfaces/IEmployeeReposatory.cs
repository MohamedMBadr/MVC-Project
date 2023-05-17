using MVC.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.BLL.interfaces
{
    public interface IEmployeeReposatory :IGenaricReposatory<Employee>
    {
      
        IQueryable<Employee> searchEmployeByName(string employeName);
    }
}
