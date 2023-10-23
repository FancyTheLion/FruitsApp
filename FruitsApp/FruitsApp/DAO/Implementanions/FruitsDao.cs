using FruitsApp.DAO.Abstract;
using FruitsApp.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.DAO.Implementanions
{
    public class FruitsDao : IFruitsDao
    {
        private readonly MainDbContext _mainDbContext;

        public FruitsDao()
        {
            _mainDbContext = new MainDbContext();
        }

        public void AddFruit(FruitDbo fruit)
        {
            fruit.Id = Guid.Empty; // К нам мог прийти фрукт с уже определённым первичным ключом, замазываем его

            _mainDbContext.Fruits.Add(fruit);
            _mainDbContext.SaveChanges();
        }

        public IReadOnlyCollection<FruitDbo> GetFruitsByName(string name)
        {
            var dbFruits = _mainDbContext
                .Fruits
                .Where(f => f.Name == name)
                .OrderBy(f => f.Name)
                .ToList();

            return dbFruits;
        }

        public IReadOnlyCollection<FruitDbo> GetFruitsOrderedByName()
        {
            var dbFruits = _mainDbContext
                .Fruits
                .OrderBy(f => f.Name)
                .ToList();

            return dbFruits;
        }
    }
}
