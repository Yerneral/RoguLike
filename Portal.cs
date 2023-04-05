namespace Roguelike
{
    internal class Portal
    {
        public int x;
        public int y;
        public char symbol = 'O';
        public void RandomPosition(Map map)
        {
            Random random = new Random();
            int portalX, portalY;
            while (true)
            {
                portalX = random.Next(0, Map.MAP_WIDTH);
                portalY = random.Next(0, Map.MAP_HEIGHT);
                if (map.map[portalY, portalX] == '.')
                {
                    Portal portal = new Portal();
                    this.x = portalX;
                    this.y = portalY;
                    map.map[portalY, portalX] = portal.symbol;
                    break;
                }

            }
        }
        public Map Start (Map map)
        {
            map.CreateMap();
            return map;
        }
    }
}
