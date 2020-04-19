using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_2020.Models;

namespace WebStore_2020.Infrastructure.Interfaces
{
    public interface ICigaretteService
    {
        void AddNew(Ciggarets cigarette);
        void Remove(int id);
        IEnumerable<Ciggarets> GetAll();
        Ciggarets GetById(int id);
        void Commit();
    }
}
