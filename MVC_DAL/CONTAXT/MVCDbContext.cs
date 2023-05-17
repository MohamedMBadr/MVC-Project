using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVC.DAL.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.CONTAXT
{
    public class MVCDbContext : IdentityDbContext<ApplicationUser> 
    {
        public MVCDbContext(DbContextOptions<MVCDbContext> options):base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get;set; }

       
    }

}
