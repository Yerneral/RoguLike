namespace Roguelike
{
    public class Armor : Item
    {
        public int armor { get; set; }
        public char symbol = 'A';
        public Armor(int price, int armor) : base(price)
        {
            this.armor = armor;
        }
        public override void Print()
        {
            Console.WriteLine($"броня имеет защиту = {armor} и стоимость = {price}");
        }

    }
}
