using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Models;

namespace WebStore_2020.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [Route("all")]
        public IActionResult Index()
        {
            //return Content("Hello from controller");
            return View(employeeService.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int id) 
        {
            return View(employeeService.GetById(id));
        }

        [Route("edit/{id?}")]
        public IActionResult Edit(int? id) 
        {
            if (!id.HasValue)
                return View(new EmployeeViewModel());
            var model = employeeService.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (model != null && model.Id > 0)
            {
                EmployeeViewModel currentModel = employeeService.GetById(model.Id);
                if (!ReferenceEquals(currentModel, null))
                {
                    currentModel.Id = model.Id;
                    currentModel.FirstName = model.FirstName;
                    currentModel.SecondName = model.SecondName;
                    currentModel.Patronymic = model.Patronymic;
                    currentModel.Position = model.Position;
                }
            }
            else
            {
                employeeService.AddNew(model);
            }
            employeeService.Commit();//transaction to database. currently not actual
            return RedirectToAction(nameof(Index));
        }
    }
}