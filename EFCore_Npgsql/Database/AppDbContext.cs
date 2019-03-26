using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tutorial.Characters;
using Tutorial.Inventory;

namespace Tutorial.Database
{


    class AppDbContext : DbContext
    {

        //сторка подключения к бд.
        private static string ConnectionString = "Host=localhost;Port=5432;Database=test;Uid=test;Password=test;";

        //настройка подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);
        }
        //Добавляем класс для сохранения в дб
        //дочерние классы добавлять не нужно EFCore сам их подхватит
        public DbSet<Character> Characters { get; set; }

        // тут находится конфигурация наших сохроняемых классов
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //настроим игнорирование свойства Data  из класса Character
            //вот так игнорируются свойства класса
            modelBuilder.Entity<Character>().Ignore(c => c.Date);

            //также добавим будем игнорировать класс Item 
            //так как он входит в состав нашего класса, то EFCore попытается для него создать таблицу
            //мы же решили что будем сохраять инвентарь в виде json строки
            //вот так игнорируются классы
            modelBuilder.Ignore<Item>();

            //здесь здесь пример того как обработать данные при сохранении
            //мы будем преобразовывать массив с вещамивв строку json 
            modelBuilder
               .Entity<Character>()//выбираем объект из контекста у нас он 1
               .Property(c => c.Inventory)//выбираем свойство 
               .HasConversion( //определяем кастомные методы для обработки данных
                   i => JsonConvert.SerializeObject(i), // при сохранении
                   i => JsonConvert.DeserializeObject<List<Item>>(i) // при загрузке
               );

            //рассмотрим как сохранить отдельный объект в нашем случае Finance
            //в одной таблице с основным классом
            modelBuilder.Entity<Character>()//выбираем объект из контекста у нас он 1
                .OwnsOne(c => c.Finance);//определяем свойство которое мы хотим добавить к текущей таблице в базе дбазе данных 

        }
    }
}
