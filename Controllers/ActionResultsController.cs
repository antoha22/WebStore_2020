using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore_2020.Controllers
{
    public class ActionResultsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}