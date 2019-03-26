using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial.Inventory
{
    class Item
    {
        //для элементов сохраняющихся в оттдельных таблицах обязательно поле с primary key
        //Достаточно создать свойство  Id и EFCore сделает все за вас
        //В конкретном случае мы не добавляем свойство Id так как Item  будет сохранен в виде json строки
        //смотрите настройки в классе AppDbContext
        //public int Id { get; set; }
        public string ClassName { get; set; }
        public int Count { get; set; }
    }
}
