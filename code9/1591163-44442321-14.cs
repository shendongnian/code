    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IGreeting, Greeting>(),
                Component.For<IGreetingFactory>().AsFactory(),
                Component.For<IGreetingService, GreetingService>(),
                Component.For<ILanguageFactory, LanguageFactory>());
        }
    }
    public interface ILanguageFactory
    {
        ILanguage Create(string language);
    }
    public class LanguageFactory : ILanguageFactory
    {
        private readonly IKernel kernel;
        public LanguageFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }
        public ILanguage Create(string language)
        {
            switch (language)
            {
                case "S":
                    return kernel.Resolve<Spanish>();
                default:
                    throw new ArgumentException();
            }
        }
    }
    public class GreetingService : IGreetingService
    {
        private readonly IGreetingFactory greetingFactory;
        private readonly ILanguageFactory languageFactory;
        private IGreeting greeting;
        public GreetingService(IGreetingFactory greetingFactory, ILanguageFactory languageFactory)
        {
            // store the factory until we need it
            this.greetingFactory = greetingFactory;
        }
        public string SayHello (string strLanguage)
        {
            var language = languageFactory.Create(strLanguage);
            greeting = greetingFactory.Create(language);
            return greeting.SayHello();
        }
    }
