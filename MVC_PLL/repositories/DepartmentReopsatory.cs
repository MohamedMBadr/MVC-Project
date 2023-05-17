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
    public class DepartmentReopsatory :GenaricReposatory<Department> , IdepartmentReposatory 
    {
        public DepartmentReopsatory( MVCDbContext dbContext):base(dbContext) { }
       
    }
}

