namespace rpg_console
{
    public class DrawPerson
    {
        public void idlePlayer(string file_1, string file_2, string file_3, string file_4)
        {
            string fileC_1 = File.ReadAllText(file_1);
            string fileC_2 = File.ReadAllText(file_2);
            string fileC_3 = File.ReadAllText(file_3);
            string fileC_4 = File.ReadAllText(file_4);

            Console.SetCursorPosition(0, 0);

            Console.WriteLine(fileC_1);
            Thread.Sleep(500);

            Console.SetCursorPosition(0, 0);

            Console.WriteLine(fileC_2);
            Thread.Sleep(500);

            Console.SetCursorPosition(0, 0);

            Console.WriteLine(fileC_3);
            Thread.Sleep(500);

            Console.SetCursorPosition(0, 0);

            Console.WriteLine(fileC_4);
            Thread.Sleep(500);

        }

        public void attackPlayer(string file_1, string file_2, string file_3, string file_4)
        {
            string fileC_1 = File.ReadAllText(file_1);
            string fileC_2 = File.ReadAllText(file_2);
            string fileC_3 = File.ReadAllText(file_3);
            string fileC_4 = File.ReadAllText(file_4);

            for (int i = 0; i < 1; i++)
            {
                Console.SetCursorPosition(0, 0);


                Console.WriteLine(fileC_1);
                Thread.Sleep(500);
                Console.Clear();

                Console.SetCursorPosition(0, 0);

                Console.WriteLine(fileC_2);
                Thread.Sleep(500);
                Console.Clear();


                Console.SetCursorPosition(0, 0);

                Console.WriteLine(fileC_3);
                Thread.Sleep(500);
                Console.Clear();


                Console.SetCursorPosition(0, 0);

                Console.WriteLine(fileC_4);

                Thread.Sleep(500);
                Console.Clear();

            }
        }
    }
}

