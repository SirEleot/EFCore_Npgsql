using System;
using System.Collections.Generic;
using System.Text;
using Tutorial.Characters;
using Tutorial.Database;
using Tutorial.Inventory;

namespace Tutorial
{
    public class TestUser
    {
        public static void Main(string[] args)
        {
            Registration("TestName", "TestLastName", "TestPassword");
        }

        public static void Registration(string name, string lastname, string password)
        {

            //не забываем про хеширование пароля перед сохранением в бд

            //создаем нового персонажа 
            Character Char = new Character
            {
                Social = "TestSocial",
                Name = name,
                Lasname = lastname,
                Password = password,
                Finance = new Finances(),
                State = new States(),
                Inventory = new List<Item>(),
                Date = DateTime.Now
            };

            //добавляем его в контекст данных
            Db.Instance.Add(Char);

            //сохранянем изменения в базе данных
            Db.Instance.SaveChanges();
        }
    }
}
