using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Roguelike;
using rpg_console;
using SceneStructerDemo;
using SceneStructerDemo.Scenes;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

namespace RoguLike2.Scenes
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {
        }
        public override void Run()
        {
            Random random = new Random();
            int lvl = 1;
            //создание карты
            Map map = new Map();
            map.CreateMap();
            //создание торговца
            Trader trader = new Trader();
            trader.RandomPosition(map);

            //создание персонажа

            Person ivan = new Person("Иван", 100, 1, 10, 10, 0, '@');
            Console.WriteLine(@"Выбор был не легким, соглашусь...
Вы уверены в своем выборе, что хотите выбрать данный класс?
Введите номер класса, которого вы окончательно выбрали.

1 - Рыцарь. Здоровье: 100. Урон: 10. Броня: 10. 700 монет.
2 - Гном.   Здоровье: 100. Урон: 5. Броня: 15. 300 монет.
3 - Орк     Здоровье: 100. Урон: 15. Броня: 5. 100 монет.");

            int tmp = Convert.ToInt32(Console.ReadLine());// доп. подтверждение выбора класса
            Console.Clear();

            if(tmp == 1)
            {
                ivan.money = 700;
                ivan.name = "Рыцарь";
            }
            if (tmp == 2)
            {
                ivan.damage = 5;
                ivan.armor = 15;
                ivan.money = 300;
                ivan.name = "Гном";
            }
            if (tmp == 3)
            {
                ivan.damage = 15;
                ivan.armor = 5;
                ivan.money = 100;
                ivan.name = "Орк";
            }
            if (tmp == 666)
            {
                ivan.lvl = 10;
                ivan.health = 1000;
                ivan.damage = 1500000;
                ivan.armor = 500000;
                ivan.money = 100000;
                ivan.name = "Админ";
            }

            char curChar = ivan.RandomPosition(map); //переменная, которая хранит текущую клетку на которой стоял персонаж. 
            int playerX = ivan.X, playerY = ivan.Y; //координаты игрока 

            //рандомная генерация противников 
            List<Enemy> enemy = new List<Enemy>();
            Enemy.RandomGeneration(enemy, map, 11, lvl);

            //рандомная генерация портала
            Portal portal = new Portal();
            portal.RandomPosition(map);

            int LVL_Hero = 9;

            //передвижение персонажа 
            while (true)
            {
                map.PrintMap();
                while (Console.KeyAvailable)
                {                   
                    Console.ReadKey();
                }
               
                ConsoleKey consoleKey = Console.ReadKey(true).Key;
                if (consoleKey == ConsoleKey.W && map.map[playerY - 1, playerX] != ' ')
                {
                    if (map.map[playerY - 1, playerX] == '$')
                    {
                        trader.Start(ivan);
                        map.map[playerY, playerX] = curChar;
                        playerY--;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                    if (map.map[playerY - 1, playerX] == '!')
                    {
                        Console.Clear();
                        for (int i = 0; i < enemy.Count(); i++)
                        {
                            if (enemy[i].X == playerX && enemy[i].Y == playerY - 1)
                            {
                                Fight.Attack2(ivan, enemy[i]);
                                if (ivan.health > 0)
                                {
                                    enemy.RemoveAt(i);
                                    map.map[playerY, playerX] = curChar;
                                    playerY--;
                                    curChar = '.';
                                    map.map[playerY, playerX] = '@';
                                }
                            }
                        }
                        if (ivan.health <= 0)
                        {
                            break;
                        }

                    }
                    if (map.map[playerY - 1, playerX] == 'O')
                    {
                        Enemy.ClearOpponent(enemy, map);
                        map.CreateMap();
                        lvl++;
                        Enemy.RandomGeneration(enemy, map, 11, lvl);
                        trader.RandomPosition(map);
                        curChar = ivan.RandomPosition(map);
                        playerX = ivan.X;
                        playerY = ivan.Y;
                        portal.RandomPosition(map);
                        if(lvl > LVL_Hero) 
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        map.map[playerY, playerX] = curChar;
                        playerY--;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                }
                if (consoleKey == ConsoleKey.A && map.map[playerY, playerX - 1] != ' ')
                {
                    if (map.map[playerY, playerX - 1] == '$')
                    {
                        trader.Start(ivan);
                        map.map[playerY, playerX] = curChar;
                        playerX--;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                    if (map.map[playerY, playerX - 1] == '!')
                    {
                        Console.Clear();
                        for (int i = 0; i < enemy.Count(); i++)
                        {
                            if (enemy[i].X == playerX - 1 && enemy[i].Y == playerY)
                            {
                                Fight.Attack2(ivan, enemy[i]);
                                if (ivan.health > 0)
                                {
                                    enemy.RemoveAt(i);
                                    map.map[playerY, playerX] = curChar;
                                    playerX--;
                                    curChar = '.';
                                    map.map[playerY, playerX] = '@';
                                }
                            }
                        }
                        if (ivan.health <= 0)
                        {
                            break;
                        }
                    }
                    if (map.map[playerY, playerX - 1] == 'O')
                    {
                        Enemy.ClearOpponent(enemy, map);
                        map.CreateMap();
                        lvl++;
                        Enemy.RandomGeneration(enemy, map, 11, lvl);
                        trader.RandomPosition(map);
                        curChar = ivan.RandomPosition(map);
                        playerX = ivan.X;
                        playerY = ivan.Y;
                        portal.RandomPosition(map);
                        if (lvl > LVL_Hero)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        map.map[playerY, playerX] = curChar;
                        playerX--;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                }
                if (consoleKey == ConsoleKey.D && map.map[playerY, playerX + 1] != ' ')
                {
                    if (map.map[playerY, playerX + 1] == '$')
                    {
                        trader.Start(ivan);
                        map.map[playerY, playerX] = curChar;
                        playerX++;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                    if (map.map[playerY, playerX + 1] == '!')
                    {
                        Console.Clear();
                        for (int i = 0; i < enemy.Count(); i++)
                        {
                            if (enemy[i].X == playerX + 1 && enemy[i].Y == playerY)
                            {
                                Fight.Attack2(ivan, enemy[i]);
                                if (ivan.health > 0)
                                {
                                    enemy.RemoveAt(i);
                                    map.map[playerY, playerX] = curChar;
                                    playerX++;
                                    curChar = '.';
                                    map.map[playerY, playerX] = '@';
                                }
                            }
                        }
                        if (ivan.health <= 0)
                        {
                            break;
                        }
                    }
                    if (map.map[playerY, playerX + 1] == 'O')
                    {
                        Enemy.ClearOpponent(enemy, map);
                        map.CreateMap();
                        lvl++;
                        Enemy.RandomGeneration(enemy, map, 11, lvl);
                        trader.RandomPosition(map);
                        curChar = ivan.RandomPosition(map);
                        playerX = ivan.X;
                        playerY = ivan.Y;
                        portal.RandomPosition(map);
                        if (lvl > LVL_Hero)
                        {
                            break;
                        }
                    }
                    else
                    {
                        map.map[playerY, playerX] = curChar;
                        playerX++;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                }
                if (consoleKey == ConsoleKey.S && map.map[playerY + 1, playerX] != ' ')
                {
                    if (map.map[playerY + 1, playerX] == '$')
                    {
                        trader.Start(ivan);
                        map.map[playerY, playerX] = curChar;
                        playerY++;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                    if (map.map[playerY + 1, playerX] == '!')
                    {
                        Console.Clear();
                        for (int i = 0; i < enemy.Count(); i++)
                        {
                            if (enemy[i].X == playerX && enemy[i].Y == playerY + 1)
                            {
                                Fight.Attack2(ivan, enemy[i]);
                                if (ivan.health > 0)
                                {
                                    enemy.RemoveAt(i);
                                    map.map[playerY, playerX] = curChar;
                                    playerY++;
                                    curChar = '.';
                                    map.map[playerY, playerX] = '@';
                                }
                            }
                        }
                        if (ivan.health <= 0)
                        {
                            break;
                        }
                    }
                    if (map.map[playerY + 1, playerX] == 'O')
                    {
                        Enemy.ClearOpponent(enemy, map);
                        map.CreateMap();
                        lvl++;
                        Enemy.RandomGeneration(enemy, map, 11, lvl);
                        trader.RandomPosition(map);
                        curChar = ivan.RandomPosition(map);
                        playerX = ivan.X;
                        playerY = ivan.Y;
                        portal.RandomPosition(map);
                        if (lvl > LVL_Hero)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        map.map[playerY, playerX] = curChar;
                        playerY++;
                        curChar = map.map[playerY, playerX];
                        map.map[playerY, playerX] = '@';
                    }
                }
                ivan.X = playerX;
                ivan.Y = playerY;
                foreach (Enemy i in enemy)
                {
                    i.RandomMovement(map);
                }
            }
            if (ivan.health <= 0)
            {
                string TitleArt = @"
 ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝
                                                                          
";
                string prompt = $@"{TitleArt}
Начать заного?";

                string[] option = { "Да", "Нет" };
                Menu menu = new Menu(prompt, option);

                int selectIndex = menu.Run();
                switch (selectIndex)
                {
                    case 0:
                        Console.Clear();
                        MyGame.MyMapScene.Run();
                        break;
                    case 1:
                        ConsoleUtils.QuitConsole();
                        break;

                }
                Console.Clear();
            }           
            if (lvl > LVL_Hero)
            {
                Console.Clear();
                string TitleArt = @"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗██╗██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║██║██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║██║██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝╚═╝╚═╝
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗██╗██╗
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝╚═╝╚═╝
                                                               
                                                                          
";
                string prompt = $@"{TitleArt}
Начать заного?";

                string[] option = { "Да", "Нет" };
                Menu menu = new Menu(prompt, option);

                int selectIndex = menu.Run();
                switch (selectIndex)
                {
                    case 0:
                        Console.Clear();
                        MyGame.MyMapScene.Run();
                        break;
                    case 1:
                        ConsoleUtils.QuitConsole();
                        break;
                       
                }
            }
        }
    }

}





