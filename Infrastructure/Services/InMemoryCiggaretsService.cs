using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_2020.Infrastructure.Interfaces;
using WebStore_2020.Models;

namespace WebStore_2020.Infrastructure.Services
{
    public class InMemoryCiggaretsService : ICigaretteService
    {
        private List<Ciggarets> ciggerets;
        public InMemoryCiggaretsService()
        {
            ciggerets = new List<Ciggarets>
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
        }
        public void AddNew(Ciggarets cigarette)
        {
            cigarette.Id = ciggerets.Max(ciggaretes => ciggaretes.Id) + 1;
            ciggerets.Add(cigarette);
        }

        public void Commit()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Ciggarets> GetAll()
        {
            return ciggerets;
        }

        public Ciggarets GetById(int id)
        {
            return ciggerets.FirstOrDefault(ciggerete => ciggerete.Id == id);
        }

        public void Remove(int id)
        {
            ciggerets.Remove(GetById(id));
        }
    }
}
