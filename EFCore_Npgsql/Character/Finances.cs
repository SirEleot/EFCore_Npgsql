namespace Tutorial.Characters
{
    class Finances
    {
        //для элементов сохраняющихся в оттдельных таблицах обязательно поле с primary key
        //Достаточно создать свойство  Id и EFCore сделает все за вас
        //В конкретном случае мы не добавляем свойство Id так как Finance будет помещен в одну таблицу с Character
        //смотрите настройки в классе AppDbContext
        //public int Id { get; set; }
        public int Bank { get; set; } = 5000;
        public int Cash { get; set; } = 500;

        //добавить деньги на счет
        public bool AddBank(int amount)
        {
            Bank += amount;
            return true;
        }

        //списать деньги со счета
        public bool SubBank(int amount)
        {
            if (amount > Bank) return false;
            Bank -= amount;
            return true;
        }
        //......
    }
}
