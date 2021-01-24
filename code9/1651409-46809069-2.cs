    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = new ExWindow();
            window.Show();
        }
    }
