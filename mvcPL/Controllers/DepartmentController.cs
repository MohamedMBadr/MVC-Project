using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.BLL.interfaces;
using MVC.BLL.repositories;
using MVC.DAL.models;
using System;
using System.Threading.Tasks;

namespace MVC.PL.Controllers
{
	[Authorize]

	public class DepartmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // private readonly IdepartmentReposatory _departmentReposatory;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
           // _departmentReposatory= departmentReposatory;
          _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var departments =await _unitOfWork.DepartmentReposatory.GetAll();

            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWork.DepartmentReposatory.Add(department);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            return View(department);
            
        }

        public async Task< IActionResult> Details(int? id , string viewName="details")
        {
            if (id is null)
                return BadRequest();
            var department =await _unitOfWork.DepartmentReposatory.Get(id.Value);
            if (department is null)
                return NotFound();
            return View(viewName, department);
        }
     
        public async  Task<IActionResult> Edit(int? id)
        {
            return await Details(id, "Edit");
           /// if (id is null)
           ///     return BadRequest();
           /// var department = _departmentReposatory.Get(id.Value);
           /// if (department is null)
           ///     return NotFound();
           /// return View(department);
           ///
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Edit([FromRoute] int id , Department department)
        {
            if (id != department.id)
                return BadRequest();
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.DepartmentReposatory.Update(department);
                     await      _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));

                }
            }
            catch (Exception ex)
            { 

                ModelState.AddModelError(string.Empty , ex.Message);

            }

            return View(department);
        }


        public async  Task<IActionResult> Delete(int? id)
        {
            
            return await Details(id, "Delete");
        }
        [HttpPost]
        public async Task< IActionResult> Delete([FromRoute] int id ,Department department)
        {
            if (id != department.id)
                return BadRequest();
            try
            {
                _unitOfWork.DepartmentReposatory.Delete(department);
                await _unitOfWork.Complete();

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty , ex.Message);
            }
            return View(department);
        }
    }
}

