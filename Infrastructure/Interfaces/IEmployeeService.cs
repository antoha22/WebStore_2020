using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_2020.Models;

namespace WebStore_2020.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeViewModel> GetAll();

        EmployeeViewModel GetById(int id);

        void Commit();

        void AddNew(EmployeeViewModel model);

        void Delete(int id);
    }
}
