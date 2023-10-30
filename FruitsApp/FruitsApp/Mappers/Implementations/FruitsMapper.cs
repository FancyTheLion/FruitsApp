using FruitsApp.DAO.Models;
using FruitsApp.Mappers.Abstract;
using FruitsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.Mappers.Implementations
{
    internal class FruitsMapper : IFruitsMapper
    {
        public Fruit Map(FruitDbo fruit)
        {
            return new Fruit()
            {
                Id = fruit.Id,
                Name = fruit.Name,
                Weight = fruit.Weight,
                Color = fruit.Color,
                PeelThickness = fruit.PeelThickness
            };
        }

        public FruitDbo Map(Fruit fruit)
        {
            return new FruitDbo()
            {
                Id = fruit.Id,
                Name = fruit.Name,
                Weight = fruit.Weight,
                Color = fruit.Color,
                PeelThickness = fruit.PeelThickness
            };
        }

        public IReadOnlyCollection<Fruit> Map(IReadOnlyCollection<FruitDbo> fruits)
        {
            return fruits
                .Select(fruits => Map(fruits))
                .ToList();
        }

        public IReadOnlyCollection<FruitDbo> Map(IReadOnlyCollection<Fruit> fruits)
        {   
            return fruits
                .Select(fruits => Map(fruits))
                .ToList();
        }
    }
}
