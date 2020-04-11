using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Models;

namespace WebStore_2020.Controllers
{
    public class CigaretteController : Controller
    {
        List<Ciggarets> ciggaretsList = new List<Ciggarets>
        {
            new Ciggarets
            {
                PickUrl = @"https://www.tabacum.ru/images/luckystrire1.jpg",
                Label = "LuckyStrike",
                Cost = 148,
                Model = "Classic Red",
                Id = 1
            },
            new Ciggarets
            {
                PickUrl = @"https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRqySLOmMLS7hIlBJtSZskTAZDBIHExGrIc_pste-FW7jrNye_R&usqp=CAU",
                Label = "LuckyStrike",
                Cost = 148,
                Model = "Classic Blue",
                Id = 2
            }
        };
        public IActionResult ReturnList()
        {
            return View(ciggaretsList);
        }

        public IActionResult Details(int id) 
        {
            return View(ciggaretsList.FirstOrDefault((ci) => ci.Id == id ));
        }
    }
}