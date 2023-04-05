using static System.Console;

namespace SceneStructerDemo
{
    static class ConsoleUtils // чтобы не закрывалось окно
    {
        public static void WaitForKeyPress()
        {
            WriteLine("Нажмите, чтобы продолжить");
            ReadKey(true);
        }
        public static void QuitConsole()//выйти из игры
        {
            WriteLine("нажмите, чтобы продолжить");
            ReadKey(true);
            Environment.Exit(0);

        }

    }
}
