using FruitsApp.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.DAO.Abstract
{
    /// <summary>
    /// DAO для работы с фруктами
    /// </summary>
    public interface IFruitsDao
    {
        /// <summary>
        /// Получить отсортированный по названию список фруктов
        /// </summary>
        IReadOnlyCollection<FruitDbo> GetFruitsOrderedByName();

        /// <summary>
        /// Положить фрукт fruit в базу данных
        /// </summary>
        void AddFruit(FruitDbo fruit);

        /// <summary>
        /// Получить из базы список фруктов с заданным именем
        /// </summary>
        IReadOnlyCollection<FruitDbo> GetFruitsByName(string name);
    }
}
