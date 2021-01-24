    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.MainWindow = new MainWindow(new MainWindowViewModel(new DbDataService()));
            MainWindow.Show();
        }
    }
