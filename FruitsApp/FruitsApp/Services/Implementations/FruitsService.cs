using FruitsApp.DAO.Abstract;
using FruitsApp.DAO.Models;
using FruitsApp.Mappers.Abstract;
using FruitsApp.Models;
using FruitsApp.Services.Abstract;

namespace FruitsApp.Services.Implementations
{
    public class FruitsService : IFruitsService
    {
        private readonly IFruitsDao _fruitsDao;
        private readonly IFruitsMapper _fruitsMapper;

        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        private readonly Random _randomGenerator = new Random();

        public FruitsService
        (
            IFruitsDao fruitsDao,
            IFruitsMapper fruitsMapper
        )
        {
            _fruitsDao = fruitsDao;
            _fruitsMapper = fruitsMapper;
        }

        public IReadOnlyCollection<Fruit> GetFruits()
        {
            var fruitsFromDb = _fruitsDao.GetFruitsOrderedByName();
            var fruits = _fruitsMapper.Map(fruitsFromDb);

            return fruits;
        }

        public void TryToAddFruitIfItDoesntExist(string fruitName)
        {
            // Нет-ли в базе уже фрукта с таким именем?
            var fruitsInDb = _fruitsDao.GetFruitsByName(fruitName);
            if (fruitsInDb.Any())
            {
                // Такой фрукт уже есть, выходим
                return;
            }

            // Создаём случайный фрукт
            var fruit = GenerateRandomFruitWithGivenName(fruitName);

            // Превращаем фрукт в модель, используемую в базе
            var fruitDbo = _fruitsMapper.Map(fruit);

            // Вставляем фрукт в базу
            _fruitsDao.AddFruit(fruitDbo);
        }

        /// <summary>
        /// Сгенерировать фрукт с заданным именем и случайными свойствами
        /// </summary>
        private Fruit GenerateRandomFruitWithGivenName(string name)
        {
            return new Fruit()
            {
                Id = Guid.Empty,
                Name = name,
                Weight = _randomGenerator.Next(50, 1001),
                Color = GenerateRandomFruitColor(),
                PeelThickness = _randomGenerator.Next(1, 201)
            };
        }

        private FruitColor GenerateRandomFruitColor()
        {
            var randomColorCode = _randomGenerator.Next(1, 4); // Число от 1 до 3

            return (FruitColor)randomColorCode; // Мы берём число и говорим "интерпретировать его как цвет"
        }

        public string GetRussianColorName(FruitColor color)
        {
            switch (color)
            {
                case FruitColor.Red:
                    return "Красный";

                case FruitColor.Green:
                    return "Зеленый";

                case FruitColor.Yellow:
                    return "Желтый";

                default:
                    throw new InvalidOperationException("Пришел неизвестный цвет.");
            }
        }
    }
}
