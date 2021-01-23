    public class App : PrismApplication
    {
        protected override void RegisterTypes()
        {
            var builder = new ContainerBuilder();
            builder.RegisterTypeForNavigation<MainPage>()
            builder.RegisterType<MyService>().As<IMyService>();
            builder.Update( Container );
        }
    }
