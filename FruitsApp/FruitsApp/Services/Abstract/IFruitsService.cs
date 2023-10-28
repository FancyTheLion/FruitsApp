using FruitsApp.DAO.Models;
using FruitsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.Services.Abstract
{
    /// <summary>
    /// Сервис для работы с фруктами
    /// </summary>
    public interface IFruitsService
    {
        /// <summary>
        /// Попытаться добавить фрукт в базу.
        /// Если фрукта в базе нет - то мы сгенерируем фрукт со случайным весом и цветом и вставим его.
        /// Если фрукт в базе есть - то делать ничего не будем.
        /// </summary>
        void TryToAddFruitIfItDoesntExist(string fruitName);

        /// <summary>
        /// Получить все фрукты из базы
        /// </summary>
        IReadOnlyCollection<Fruit> GetFruits();

        /// <summary>
        /// Получить русское название для переданного цвета
        /// </summary>
        string GetRussianColorName(FruitColor color);
    }
}
