namespace Roguelike
{
    public class Item
    {
        public int price { get; set; }

        public Item(int price)
        {
            this.price = price;
        }
        public virtual void Print()
        {

        }


    }
}
