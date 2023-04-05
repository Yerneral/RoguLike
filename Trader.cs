using SceneStructerDemo;
using SceneStructerDemo.Scenes;
using System.Numerics;

namespace Roguelike
{
    internal class Trader 
    {
        public object MyGame { get; private set; }

        public void Start(Person player)
        {
            Console.Clear();
            while (true)
            {
                player.PrintCharacteristics();
                ConsoleKey keyPressed;
                Console.WriteLine("1.Улучшить меч (+5 к атаке за 200 монет)" + '\n' +
                                  "2.улучшить броню (+5 к атаке за 200 монет)" + '\n' +
                                  "3.восстановить здровоье (1 хп за 2 монеты)" + '\n' + 
                                  "4.увеличить свой уровень (+100 к максимальному здоровью за 400 монет)");
                ConsoleKeyInfo tmp = Console.ReadKey(true);
                keyPressed = tmp.Key;
                if (keyPressed == ConsoleKey.D1 && player.money >= 200)
                {
                    player.damage += 5;
                    player.money -= 200;
                }
                if (keyPressed == ConsoleKey.D2 && player.money >= 200)
                {
                    player.armor += 5;
                    player.money -= 200;
                }
                if (keyPressed == ConsoleKey.D3 && player.health < player.lvl * 100)
                {
                    while (player.money >= 2 && player.health < player.lvl * 100)
                    {
                        player.money -= 2;
                        player.health += 1;                       
                    }
                }
                if (keyPressed == ConsoleKey.D4 && player.money >= 400)
                {
                    player.lvl++;
                    player.money -= 400;                    
                    if(player.lvl > 9)
                    {
                        break;
                    }
                }
                
                if (keyPressed == ConsoleKey.Escape)
                {
                    break;
                }
                Console.Clear();
            }
            Console.Clear();
        }
        public void RandomPosition(Map map)
        {
            Random random = new Random();
            int traderX, traderY;
            while (true)
            {
                traderX = random.Next(0, Map.MAP_WIDTH);
                traderY = random.Next(0, Map.MAP_HEIGHT);
                if (map.map[traderY, traderX] == '.')
                {
                    map.map[traderY, traderX] = '$';
                    break;
                }

            }
            
        }


    }
}
