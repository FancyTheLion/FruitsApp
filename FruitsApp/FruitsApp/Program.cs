using FruitsApp.DAO.Abstract;
using FruitsApp.DAO.Implementanions;
using FruitsApp.DAO.Models;
using FruitsApp.Mappers.Abstract;
using FruitsApp.Mappers.Implementations;
using FruitsApp.Models;
using FruitsApp.Services.Abstract;
using FruitsApp.Services.Implementations;
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
            hostApplicationBuilder.Services.AddSingleton<IFruitsService, FruitsService>();

            using IHost host = hostApplicationBuilder.Build();

            using IServiceScope serviceScope = host.Services.CreateScope();
            IServiceProvider diProvider = serviceScope.ServiceProvider;

            #endregion

            // Мы имеем право получить здесь только сервис. Программа в этом месте не должна ничего знать о мапперах и DAO
            var fruitsService = diProvider.GetService<IFruitsService>();

            // Пытаемся добавить апельсин
            fruitsService.TryToAddFruitIfItDoesntExist("Апельсин");
            fruitsService.TryToAddFruitIfItDoesntExist("Лимон");

            // Распечатываем фрукты, которые есть в базе
            Console.WriteLine("Фрукты в базе:");

            var fruits = fruitsService.GetFruits();
            foreach(var fruit in fruits)
            {
                Console.WriteLine($"Название: { fruit.Name }, вес: { fruit.Weight }, цвет: { fruitsService.GetRussianColorName(fruit.Color) }");
            }

            // Ждём завершения
            Console.WriteLine("Нажмите <Enter> для завершения");
            Console.ReadLine();
        }
    }
}