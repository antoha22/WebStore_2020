using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Models;

namespace WebStore_2020.Infrastructure.Services
{
    public class InMemoryEmployeeService : IEmployeeService
    {
        List<EmployeeViewModel> employees;
        public InMemoryEmployeeService()
        {
            employees = new List<EmployeeViewModel>
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
        }

        public void AddNew(EmployeeViewModel model)
        {
            model.Id = employees.Max(employee => employee.Id) + 1;
            employees.Add(model);
        }

        public void Commit()
        {
           // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            employees.Remove(GetById(id));
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return employees;
        }

        public EmployeeViewModel GetById(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }
    }
}
