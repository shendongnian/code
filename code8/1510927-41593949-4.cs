    static void Main(string[] args)
    {
        var game = new UnityContainer();
        game.RegisterType<IGame, TrivialPursuit>();
        game.RegisterType<IAnotherClass, AnotherClass>();
        game.RegisterType<IYetAnotherClass, YetAnotherClass>();
        var gameInstance = game.Resolve<IGame>();
        // you'll need to perform some action on gameInstance now, like gameInstance.RunGame() or whatever.
    }
    public class Game : IGame
    {
        public Game(IAnotherClass anotherClass)
        {
        }
    }    
    public class AnotherClass : IAnotherClass
    {
        public AnotherClass(IYetAnotherClass yetAnotherClass)
        {
        }
    }
    
    public class YetAnotherClass : IYetAnotherClass {}
