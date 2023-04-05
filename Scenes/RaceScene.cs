using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Roguelike;
using SceneStructerDemo;
using SceneStructerDemo.Scenes;

namespace RoguLike.Scenes
{
    internal class RaceScene : Scene
    {

        public RaceScene(Game game) : base(game)
        {
        }
        public override void Run()
        {
            string prompt = @"Выберите себе класс:
1 - Рыцарь. Здоровье: 100. Урон: 10. Броня: 10. 700 монет.
2 - Гном.   Здоровье: 100. Урон: 5. Броня: 15. 300 монет.
3 - Орк     Здоровье: 100. Урон: 15. Броня: 5. 100 монет.
";
            

            string[] option = { "Рыцарь", "Гном", "Орк " };
            Menu menu = new Menu(prompt, option);

            int selectIndex = menu.Run();
            switch (selectIndex)
            {
                case 0:
                    
                    Console.Clear();
                    MyGame.MyMapScene.Run();
                    
                    break;
                case 1:
                    Console.Clear();
                    MyGame.MyMapScene.Run();
                    break;
                case 2:
                    Console.Clear();
                    MyGame.MyMapScene.Run();
                    break;

            }
        }
    }
}



