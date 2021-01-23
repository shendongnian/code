    public class Game : IGame
    {
        public Game(IContainer container)
        {
            var blah = container.Resolve<IBlah>();
        }
    }
