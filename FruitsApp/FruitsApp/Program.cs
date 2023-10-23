using FruitsApp.DAO.Abstract;
using FruitsApp.DAO.Implementanions;
using FruitsApp.DAO.Models;
using FruitsApp.Mappers.Abstract;
using FruitsApp.Mappers.Implementations;
using FruitsApp.Models;
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
            hostApplicationBuilder.Services.AddSingleton<IFruitsMapper, FruitsMapper>();

            using IHost host = hostApplicationBuilder.Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider diProvider = serviceScope.ServiceProvider;

            #endregion

            // Получаем DAO из инжектора
            var fruits = diProvider.GetService<IFruitsDao>();
            var fruitsMapper = diProvider.GetService<IFruitsMapper>();

            // Пробуем добавить фрукт
            var lemon = new Fruit()
            {
                Name = "Лимон",
                Weight = 110,
                Color = FruitColor.Yellow
            };

            var lemonDbo = fruitsMapper.Map(lemon);

            fruits.AddFruit(lemonDbo);
        }
    }
}