using GTANetworkAPI;
using System.Linq;
using Tutorial.Characters;
using Tutorial.Database;

namespace Tutorial.Autorization
{
    class Login: Script
    {
        [RemoteEvent("srv_Login")]
        public void OnRegistration(Client client, string pwd)
        {

            //Получаем персонажа из бд 
            Character Char = Db.Instance.Characters.SingleOrDefault(c=>c.Social == client.SocialClubName);

            //проверяем пароль на совпадение (не забываем про хеш)
            if(Char.Password == pwd)
            {
                //создаем ссылку на нашу модель игрока
                client.SetData("Character", Char);
                //загружаем игрока
                //..............
            }
            else
            {
                //если не прошел проверку отправляем на повторный логин
                //................
            }
            
        }
    }
}
