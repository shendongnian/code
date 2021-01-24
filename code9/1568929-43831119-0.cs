    public class Bootstrapper : DefaultNancyBootstrapper
    {
        
        protected override void ConfigureApplicationContainer(TinyIoCContainer    container)
        {
            base.ConfigureApplicationContainer(container);
            
            container.Register<IMyDictionary, Dictionary<string,string>>().AsSingleton();
        }
    }
