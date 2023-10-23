using FruitsApp.DAO.Models;
using FruitsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.Mappers.Abstract
{
    /// <summary>
    /// Маппер для работы с фруктами
    /// </summary>
    public interface IFruitsMapper
    {
        /// <summary>
        /// Взять фрукт, пришедший из базы (FruitDbo) и сделать из него фрукт, которым пользуется вся остальная программа
        /// </summary>
        Fruit Map(FruitDbo fruit);

        /// <summary>
        /// Взять фрукт, которым пользуется программа, и сделать из него фрукт, который можно положить в базу\корзину
        /// </summary>
        FruitDbo Map(Fruit fruit);

        /// <summary>
        /// Взять список\корзину фруктов, пришедших из базы, и сделать из него список\корзину фруктов, которым пользуется вся остальная программа
        /// </summary>
        IReadOnlyCollection<Fruit> Map(IReadOnlyCollection<FruitDbo> fruits);

        /// <summary>
        /// Взять список\корзину фруктов, которым пользуется программа, и сделать из него список\корзину фруктов, готовых к покладке в базу
        /// </summary>
        IReadOnlyCollection<FruitDbo> Map(IReadOnlyCollection<Fruit> fruits);
    }
}
