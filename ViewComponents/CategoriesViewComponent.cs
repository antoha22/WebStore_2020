using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore_2020.Infrastructure.Interfaces;

namespace WebStore_2020.ViewComponents
{
    public class CategoriesViewComponent: ViewComponent
    {
        readonly IProductService productService;
        public CategoriesViewComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            return View(GetCategories());
        }

        private IEnumerable<Category> GetCategories()
        {
           return productService.GetCategories());
        }
    }
}
