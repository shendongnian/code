    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var window = new MainWindow();
            window.SourceInitialized += window_SourceInitialized;
            window.Show();
        }
        void window_SourceInitialized(object sender, EventArgs e)
        {
            var window = sender as MainWindow;
            // I know how to handle this event for this window instance
        }
    }
