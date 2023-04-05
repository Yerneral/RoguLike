using static System.Console;

namespace SceneStructerDemo
{
    class Menu
    {
        private int SelectIndex;
        private string[] Options;
        private string Promt; // надпись сверху


        public Menu(string promt, string[] options) // конструктор для создания меню выбора ответа
        {
            Promt = promt;
            Options = options;
            SelectIndex = 0;
        }


        private void DisplayOptions()
        {
            WriteLine(Promt); // выделяет выбранный ответ в меню
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOtion = Options[i];
                string prefix;// курсор меню *

                if (i == SelectIndex)
                {
                    prefix = "*";
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefix = " ";
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                WriteLine($"{prefix}<< {currentOtion} >>");
            }
            ResetColor();
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Clear();
                DisplayOptions();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                // выбор wasd
                if (keyPressed == ConsoleKey.W)
                {
                    SelectIndex--; // вверх
                    if (SelectIndex == -1) // условие когда упираемся в границы и выбор перескакивает
                    {
                        SelectIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.S)
                {
                    SelectIndex++;//вниз
                    if (SelectIndex == Options.Length)
                    {
                        SelectIndex = 0;
                    }
                }

            } while (keyPressed != ConsoleKey.Enter);

            return SelectIndex;

        }
    }
}