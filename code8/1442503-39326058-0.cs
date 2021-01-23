    public static Person FindByName(string name)
    {
         // You're coupling your implementation to how dependencies are resolved,
         // while you don't want this at all, because you won't be able to test your
         // code without configuring the inversion of control container. In other
         // words, it wouldn't be an unit test, but an integration test!
         ILogger logger = Container.Resolve<ILogger>();
    }
