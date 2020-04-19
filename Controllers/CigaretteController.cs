using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore_2020.Models;
using WebStore_2020.Infrastructure.Interfaces;

namespace WebStore_2020.Controllers
{
    [Route("ciggaretes")]
    public class CigaretteController : Controller
    {
        private readonly ICigaretteService cigaretteService;
        public CigaretteController(ICigaretteService cigaretteService)
        {
            this.cigaretteService = cigaretteService;
        }

        [Route("all")]
        public IActionResult ReturnList()
        {
            return View(cigaretteService.GetAll());
        }

        [Route("{id}")]
        public IActionResult Details(int? id) 
        {
            if (!ReferenceEquals(id, null))
                return View(cigaretteService.GetById(id.Value));
            else
                return View();
        }

        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return View(new Ciggarets());
            var model = cigaretteService.GetById(id.Value);
            if (model == null)
                return NotFound();
            return View(model);
        }

        [Route("edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(Ciggarets modele)
        {
            if (modele != null && modele.Id > 0)
            {
                Ciggarets currentModel = cigaretteService.GetById(modele.Id);
                if (!ReferenceEquals(currentModel, null))
                {
                    currentModel.PickUrl = modele.PickUrl;
                    currentModel.Label = modele.Label;
                    currentModel.Cost = modele.Cost;
                    currentModel.Model = modele.Model;
                    currentModel.Id = modele.Id;
                }
            }
            else
            {
                cigaretteService.AddNew(modele);
            }
            cigaretteService.Commit();//transaction to database. currently not actual
            return RedirectToAction(nameof(ReturnList));
        }
    }
}