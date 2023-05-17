using AutoMapper;
using MVC.DAL.models;
using MVC.PL.ViewModels;

namespace MVC.PL.Mapping_Profiles
{
    public class EmployeeProfile :Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
