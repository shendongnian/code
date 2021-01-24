    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            e.Args[0] // here's your file name
            base.OnStartup(e);
        }
    }
