namespace SceneStructerDemo.Scenes
{
    internal class EndScene : Scene
    {

        public EndScene(Game game) : base(game)
        {
        }
        public override void Run()
        {
            string prompt = "Вы дейсвтивельно хотите выйти?";

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
