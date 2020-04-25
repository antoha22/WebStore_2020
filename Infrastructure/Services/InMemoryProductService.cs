using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Entities;
using WebStore_2020.Infrastructure.Interfaces;

namespace WebStore_2020.Infrastructure.Services
{
    public class InMemoryProductService : IProductService
    {
        IEnumerable<Brand> brands;
        IEnumerable<Category> categories;
        public InMemoryProductService()
        {
            brands = new List<Brand> 
            {
                new Brand {Name = "Adidas", Id = 0, Order = 0 },
                new Brand {Name = "Adidas", Id = 0, Order = 0 },
            };
        }
        public IEnumerable<Brand> GetBrands()
        {
            return brands;
        }

        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }
    }
}
