using GTANetworkAPI;
using System;
using System.Collections.Generic;
using Tutorial.Characters;
using Tutorial.Database;
using Tutorial.Inventory;

namespace Tutorial.Autorization
{
    class Registration: Script
    {   

        [RemoteEvent("srv_Registration")]
        public void OnRegistration(Client client, string name, string lastname, string password) {

            //не забываем про хеширование пароля перед сохранением в бд
            //создаем нового персонажа 
            Character Char = new Character
            {
                Social = client.SocialClubName,
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
