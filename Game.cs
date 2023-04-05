using SceneStructerDemo.Scenes;
using RoguLike2.Scenes;
using RoguLike.Scenes;

namespace SceneStructerDemo
{
    class Game
    {
        public ExitScene Scene;
        public TitleScene MyTitleScene;
        public MapScene MyMapScene;
        public EndScene MyEndScene;
        public RaceScene MyRaceScene;
        public ExitScene MyExitScene { get; }

        public Game()
        {
            MyTitleScene = new TitleScene(this);
            MyExitScene = new ExitScene(this);
            MyMapScene = new MapScene(this);
            MyEndScene = new EndScene(this);
            MyRaceScene = new RaceScene(this);
            Map map = new Map();
        }
        public void Start()
        {
            MyTitleScene.Run();
           
        }
    }
}


