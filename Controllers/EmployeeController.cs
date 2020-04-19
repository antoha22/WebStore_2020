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
        List<EmployeeViewModel> employees;

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
    }
}