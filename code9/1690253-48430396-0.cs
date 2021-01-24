    [TestClass]
    public class HandlerSelectorTests
    {
        [TestMethod]
        public void HandlerSelectorOverridesRegistration()
        {
            using (var container = new WindsorContainer())
            {
                container.Register(Component.For<IGreetingProvider, Hello>()
                    .Named("Hello"));
                container.Register(Component.For<IGreetingProvider, Goodbye>()
                    .Named("Goodbye"));
                container.Register(Component.For<SaysSomething>()
                    .DependsOn(Dependency.OnComponent(typeof(IGreetingProvider), "Hello")));
                var handlerSelector = new MyHandlerSelector();
                container.Kernel.AddHandlerSelector(handlerSelector);
                var resolved = container.Resolve<SaysSomething>();
                Assert.AreEqual("Goodbye", resolved.SaySomething());
            }
        }
    }
    public class MyHandlerSelector : IHandlerSelector
    {
        public bool HasOpinionAbout(string key, Type service)
        {
            return key == "Hello";
        }
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            return handlers.First(handler => handler.ComponentModel.Name == "Goodbye");
        }
    }
    public class SaysSomething
    {
        private readonly IGreetingProvider _greetingProvider;
        public SaysSomething(IGreetingProvider greetingProvider)
        {
            _greetingProvider = greetingProvider;
        }
        public string SaySomething()
        {
            return _greetingProvider.GetGreeting();
        }
    }
    public interface IGreetingProvider
    {
        string GetGreeting();
    }
    public class Hello : IGreetingProvider
    {
        public string GetGreeting()
        {
            return "Hello";
        }
    }
    public class Goodbye : IGreetingProvider
    {
        public string GetGreeting()
        {
            return "Goodbye"; //Ok, it's not a greeting.
        }
    }
