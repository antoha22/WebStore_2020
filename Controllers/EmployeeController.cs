using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Models;

namespace WebStore_2020.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        List<EmployeeViewModel> employees = new List<EmployeeViewModel>
        {
            new EmployeeViewModel
            {
                Id = 1,
                Age = 22,
                FirstName = "John",
                SecondName = "Saint",
                Patronymic = "Jr",
                Position = "Developer"
            },
            new EmployeeViewModel
            {
                Id = 2,
                Age = 23,
                FirstName = "Polina",
                SecondName = "Astasheva",
                Patronymic = "Olegovna",
                Position = "Manager"
            },
        };

        [Route("all")]
        public IActionResult Index()
        {
            //return Content("Hello from controller");
            return View(employees);
        }

        [Route("{id}")]
        public IActionResult Details(int id) 
        {
            return View(employees.FirstOrDefault(x => x.Id == id));
        }
    }
}