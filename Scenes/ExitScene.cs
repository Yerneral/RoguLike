namespace SceneStructerDemo.Scenes
{
    internal class ExitScene : Scene
    {

        public ExitScene(Game game) : base(game)
        {
        }
        public override void Run()
        {
            string prompt = @"Вы уверены, что хотите выйти? （>_<）
";

            string[] option = { "Нет", "Да" };
            Menu menu = new Menu(prompt, option);

            int selectIndex = menu.Run();
            switch (selectIndex)
            {
                case 0:
                    MyGame.Start();
                    break;
                case 1:
                    ConsoleUtils.QuitConsole();
                    break;

            }
        }
    }
}
