using System;
using System.Collections.Generic;
using Tutorial.Inventory;

namespace Tutorial.Characters
{
    class Character
    {
        //для элементов хранящихся в отдельных таблицах обязательно наличие поля с атрибутом primary key
        //но в EFCore достаточно создать для класса свойство  Id и он сделает все за вас
        public int Id { get; set; }
        public string Social { get; set; }
        public string Name { get; set; }
        public string Lasname { get; set; }
        public string Password { get; set; }

        // поместим финансовую модель в одну таблицу с персонажем 
        //состояние персонажа будет автоматом помещено в отдельную таблицу
        //все настройки производятся в классе AppDbContext 
        public Finances Finance { get; set; }
        public States State { get; set; }

        //так же мы сохраним список вещей в основную таблицу персонажа в виде строки JSON
        //настройка так же в классе AppDbContext 
        public List<Item> Inventory { get; set; }

        //это свойство создано для примера, мы его будем игнорировать при сохранении данных в базу
        //не поверите но это тоже настроим в  классе AppDbContext 
        public DateTime Date { get; set; }
    }
}
