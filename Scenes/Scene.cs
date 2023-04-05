namespace SceneStructerDemo.Scenes
{
    internal class Scene
    {
        protected Game MyGame;

        public Scene(Game game)
        {
            MyGame = game;
        }


        virtual public void Run()
        {

        }
    }
}
