using Roguelike;

namespace rpg_console
{
    internal class Fight
    {
        public static void Attack2 (Person player, Enemy enemy)
        {
            bool tmp = true;
            while (player.health > 0 && enemy.health > 0)
            {
                
                DrawPerson a = new DrawPerson();
                a.idlePlayer("idleA_B_0.txt", "idleA_B_1.txt", "idleA_B_2.txt", "idleA_B_3.txt");

                player.PrintCharacteristics();
                enemy.PrintCharacteristics();
                if (tmp == true)
                {
                    Console.WriteLine("Что вы выберите защищаться или аттаковать ? 1 - аттака");
                    int userInput = Console.ReadKey().KeyChar;
                    if (userInput == '1')
                    {
                        Console.Clear();
                        if (enemy.armor >= player.damage)
                        {
                            enemy.health -= 1;
                        }
                        else
                        {
                            enemy.health = enemy.health + enemy.armor - player.damage;
                        }
                        Thread attackThread = new Thread(() => a.attackPlayer("AttackLeft_0.txt", "AttackLeft_1.txt", "AttackLeft_2.txt", "AttackLeft_3.txt"));
                        attackThread.Start();
                        attackThread.Join();
                    }
                }
                else
                {
                    Thread attackThread = new Thread(() => a.attackPlayer("AttackRight_0.txt", "AttackRight_1.txt", "AttackRight_2.txt", "AttackRight_3.txt"));
                    attackThread.Start();
                    attackThread.Join();
                    if (player.armor >= enemy.damage)
                    {
                        player.health -= 1;
                    }
                    else
                    {
                        player.health = player.health + player.armor - enemy.damage;
                    }
                }
                tmp = !tmp;
            }
            if (player.health > 0)
            {
                player.money += enemy.money;
            }
        }
        
    }
}