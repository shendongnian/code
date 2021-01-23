    public class App : PrismApplication
    {
        protected override void RegisterTypes()
        {
            Builder.RegisterTypeForNavigation<MainPage>()
            Builder.RegisterType<MyService>().As<IMyService>();
        }
    }
