namespace Roguelike
{
    public class Enemy : Entity
    {
        public int X;
        public int Y;
        public Enemy(string name, int health, int lvl, int damage, int armor, int money, char symbol) : base(name, health, lvl, damage, armor, money, symbol) { }
        public void RandomPosition(Map map)
        {
            Random random = new Random();
            int EnemyX, EnemyY;
            while (true)
            {
                EnemyX = random.Next(0, Map.MAP_WIDTH);
                EnemyY = random.Next(0, Map.MAP_HEIGHT);

                if (map.map[EnemyY, EnemyX] == '.')
                {
                    map.map[EnemyY, EnemyX] = '!';
                    this.X = EnemyX;
                    this.Y = EnemyY;
                    break;
                }
            }
        }
        public void RandomMovement (Map map)
        {
            Random random = new Random();
            int tmp = random.Next(0, 4);
            if (tmp == 0 && map.map[this.Y - 1, this.X] == '.')
            {
                map.map[this.Y, this.X] = '.';
                this.Y--;
                map.map[this.Y, this.X] = '!';
            }
            if (tmp == 1 && map.map[this.Y, this.X - 1] == '.')
            {
                map.map[this.Y, this.X] = '.';
                this.X--;
                map.map[this.Y, this.X] = '!';
            }
            if (tmp == 2 && map.map[this.Y + 1, this.X] == '.')
            {
                map.map[this.Y, this.X] = '.';
                this.Y++;
                map.map[this.Y, this.X] = '!';
            }
            if (tmp == 3 && map.map[this.Y, this.X + 1] == '.')
            {
                map.map[this.Y, this.X] = '.';
                this.X++;
                map.map[this.Y, this.X] = '!';
            }
        }
        public static void RandomGeneration (List<Enemy> enemy, Map map, int tmp, int lvl)
        {
            for (int i = 0; i < tmp; i++)
            {
                Random random = new Random();
                int health = 10 * lvl;
                int damage = 10 * lvl;
                int armor = 10 * lvl;
                int money = random.Next(50, 150);
                Enemy opponent = new Enemy("Враг", health, lvl, damage, armor, money, '!');
                opponent.RandomPosition(map);
                enemy.Add(opponent);
            }
        }
        public static void ClearOpponent (List<Enemy> enemy, Map map)
        {
            foreach(Enemy i in enemy)
            {
                map.map[i.Y, i.X] = ' ';   
            }
            enemy.Clear();
        }
    }
}
