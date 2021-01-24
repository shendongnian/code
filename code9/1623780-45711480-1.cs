    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Create the startup window 
            MainWindow wnd = new MainWindow();
            // Do stuff here, e.g. to the window 
            wnd.Title = "Something else for fs";
            // Show the window 
            wnd.Show();
        }
    }
