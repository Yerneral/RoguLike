namespace Roguelike
{
    public class Entity
    {
        public string name { get; set; }
        public int health { get; set; }
        public int lvl { get; set; }
        public int damage { get; set; }
        public int armor { get; set; }
        public int money { get; set; }
        public char symbol { get; set; }
        public List<Item> inventory = new List<Item>();

        public Entity(string name, int health, int lvl, int damage, int armor, int money, char symbol)
        {
            this.name = name;
            this.health = health;
            this.lvl = lvl;
            this.damage = damage;
            this.armor = armor;
            this.money = money;
            this.symbol = symbol;
        }
        public void PrintCharacteristics()
        {
            Console.WriteLine($"имя: {name}" + '\n' + $"здоровье: {health}" + '\n' + $"уровень: {lvl}" + '\n' + $"урон: {damage}" + '\n' + $"броня: {armor}" + '\n' + $"деньги: {money}" + '\n');
        }
        public void TakeDamage(int damage)
        {
            int tmp = damage - this.armor;
            if (tmp < 0)
            {
                tmp = 0;
            }
            this.health -= tmp;
        }
        //public void Sale(int money)
        //{
        //    this.money += money;
        //}
        //public void Buy(int money)
        //{
        //    this.money -= money;
        //}

        
        public void PrintInventory () 
        {            
            Console.WriteLine("Инвернтарь: ");
            Console.WriteLine($"{money} монет ");
            foreach (Item i in inventory)
            {
                i.Print();
            }
        }
    }
}
