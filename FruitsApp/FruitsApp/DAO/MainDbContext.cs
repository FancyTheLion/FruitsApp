using FruitsApp.DAO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitsApp.DAO
{
    public class MainDbContext : DbContext
    {
        private string _dbPath;

        /// <summary>
        /// Таблица с фруктами
        /// </summary>
        public DbSet<FruitDbo> Fruits { get; set; }

        public MainDbContext()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = System.IO.Path.Join(path, "fruits.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={_dbPath}");
        }
    }
}
