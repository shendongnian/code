    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Resources.Culture = System.Threading.Thread.CurrentThread.CurrentCulture;
        }
    }
