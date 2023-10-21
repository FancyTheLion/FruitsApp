using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.DAO.Models
{
    /// <summary>
    /// Класс "Фрукт" в базе данных
    /// </summary>
    public class FruitDbo
    {
        /// <summary>
        /// Уникальный идентификатор фрукта
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// Название фрукта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сколько весит фрукт
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Цвет фрукта
        /// </summary>
        public FruitColor Color { get; set; }
    }
}
