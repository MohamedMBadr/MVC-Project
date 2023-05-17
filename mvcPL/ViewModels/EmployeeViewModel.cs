using MVC.DAL.models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace MVC.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required ")]
        [MaxLength(50, ErrorMessage = "Max lenth is 50 chars")]
        [MinLength(3, ErrorMessage = "min lenth is 3 chars")]
        public string Name { get; set; }
        [Range(22, 33)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}-[a-zA-Z]{3,10}$", ErrorMessage = "addres must be like 123-street-city-country")]
        public string Addres { get; set; }
    
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }
        public DateTime DateOfCreation { get; set; }

        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
        public Department Department { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DepartmentId { get; set; }


    }

}
