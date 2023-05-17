using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.models
{
    public class Department
    {
        public int id { get; set; }

        [Required (ErrorMessage ="code is required !!")]
        public string code { get; set; } 
        
        [Required (ErrorMessage ="Name is required !!")]

        public string name { get; set; }

        public DateTime dateOfCreation { get; set; }

        public ICollection<Employee> employees { get; set; }= new HashSet<Employee>();

    }
}
