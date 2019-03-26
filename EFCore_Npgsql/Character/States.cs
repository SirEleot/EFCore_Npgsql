namespace Tutorial.Characters
{
    class States
    {
        //для элементов сохраняющихся в отдельных таблицах обязательно поле с primary key
        //Достаточно создать свойство  Id и EFCore сделает все за вас
        public int Id { get; set; }
        public int Health { get; set; } = 100;
        public int Armor { get; set; } = 100;
    }
}
