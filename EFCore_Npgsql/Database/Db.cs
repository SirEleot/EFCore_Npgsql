namespace Tutorial.Database
{
    class Db
    {
        //локальная ссылка на подключение
        private static AppDbContext _instance;

        //возвращает текущее подключенеие к базе или создает новое при его отсутствии
        public static AppDbContext Instance
        {
            get
            {
                if (_instance == null) return Instance = new AppDbContext();

                return _instance;
            } 
                
            set { }
        }
    }
}
