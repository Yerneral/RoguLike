namespace Roguelike
{
    public class Person : Entity
    {
        public int X;
        public int Y;
        public Person(string name, int health, int lvl, int damage, int armor, int money, char symbol) : base(name, health, lvl, damage, armor, money, symbol)
        {

        }
        public char RandomPosition(Map map)
        {
            Random random = new Random();
            int playerX, playerY;
            char curChar;
            while (true)
            {
                playerX = random.Next(0, Map.MAP_WIDTH);
                playerY = random.Next(0, Map.MAP_HEIGHT);

                if (map.map[playerY, playerX] == '.')
                {
                    map.map[playerY, playerX] = '@';
                    curChar = '.';
                    this.X = playerX;
                    this.Y = playerY;
                    break;
                }
            }
            return curChar;
        }

    }
}
