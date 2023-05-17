using AutoMapper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.BLL.interfaces;
using MVC.DAL.models;
using MVC.PL.Helper;
using MVC.PL.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.PL.Controllers
{
	[Authorize]

	public class EmployeeController : Controller
    {

        //private readonly IEmployeeReposatory _EmployeeReposatory;
        //private readonly IdepartmentReposatory _departmentReposatory;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public EmployeeController(IUnitOfWork unitOfWork , IMapper mapper)
        {

            //_EmployeeReposatory = employeeReposatory;
            //_departmentReposatory = departmentReposatory;
            _unitOfWork= unitOfWork; 
            _mapper = mapper;
        }
        public async Task<IActionResult> Index( string SearchValue)
        {
            //ViewData["massage"] = "Hello View data";
            //ViewBag.massage= "Hello View Bag";
            IEnumerable<Employee> employees;
            if(string.IsNullOrEmpty(SearchValue) )
            {
                employees = await _unitOfWork.EmployeeReposatory.GetAll();

            }
            else
            {
                employees =  _unitOfWork.EmployeeReposatory.searchEmployeByName(SearchValue);
               
            }
            var mappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);
            return View(mappedEmp);

        }
        public IActionResult Create()
        {
            //ViewData["Departments"] = _unitOfWork.DepartmentReposatory.GetAll() ;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( EmployeeViewModel EmployeeVm)  
        {
            if (ModelState.IsValid)
            {

                EmployeeVm.ImageName= DocumentSettings.UploadFile(EmployeeVm.Image, "images");
                var mappedEmp=_mapper.Map<EmployeeViewModel, Employee>(EmployeeVm);
                await _unitOfWork.EmployeeReposatory.Add(mappedEmp);


                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(EmployeeVm);

        }

        public async Task<IActionResult> Details(int? id, string viewName = "Details")
        {
            if (id is null)
                return BadRequest();
            var Employee =await _unitOfWork.EmployeeReposatory.Get(id.Value);
            if (Employee is null)
                return NotFound();
            var mappedEmp= _mapper.Map<Employee, EmployeeViewModel>(Employee);
            return View(viewName, mappedEmp);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
            ///if (id is null)
            ///    return BadRequest();
            ///var Employee = _EmployeeReposatory.Get(id.Value);
            ///if (Employee is null)
            ///    return NotFound();
            ///return View(Employee);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit([FromRoute] int id, EmployeeViewModel EmployeeVM)
        {
            if (id != EmployeeVM.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                try
                {
                    var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(EmployeeVM);
                    _unitOfWork.EmployeeReposatory.Update(mappedEmp);
                    await _unitOfWork.Complete();

                    return RedirectToAction(nameof(Index));

                }
                catch (Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            return View(EmployeeVM);
        }


        public async  Task<IActionResult> Delete(int? id)
        {

            return await Details(id, "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] int id, EmployeeViewModel EmployeeVM)
        {
            if (id != EmployeeVM.Id) 
                return BadRequest();
            try
            {
                var mappedEmp = _mapper.Map<EmployeeViewModel, Employee>(EmployeeVM);


                _unitOfWork.EmployeeReposatory.Delete(mappedEmp);
                 int count = await  _unitOfWork.Complete();
                if (count > 0)
                    DocumentSettings.DeleteFile(EmployeeVM.ImageName, "Images");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(EmployeeVM);
        }
    }
}
