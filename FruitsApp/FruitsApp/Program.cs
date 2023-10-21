using FruitsApp.DAO.Abstract;
using FruitsApp.DAO.Implementanions;
using FruitsApp.DAO.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FruitsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region DI setup

            HostApplicationBuilder hostApplicationBuilder = Host.CreateApplicationBuilder(args);

            // Настраиваем связки между интерфейсами и реализациями
            hostApplicationBuilder.Services.AddSingleton<IFruitsDao, FruitsDao>();

            using IHost host = hostApplicationBuilder.Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider diProvider = serviceScope.ServiceProvider;

            #endregion

            // Получаем DAO из инжектора
            var fruitsDao = diProvider.GetService<IFruitsDao>();

            // Пробуем добавить фрукт
            var orange = new FruitDbo()
            {
                Name = "Апельсин",
                Weight = 150,
                Color = FruitColor.Red
            };

            fruitsDao.AddFruit(orange);
        }
    }
}