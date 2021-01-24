    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var yourDependency = await YourClass.CreateAsync();
            MainWindowViewModel vm = new MainWindowViewModel(yourDependency);
            MainWindow mainWindow = new WpfApplication4.MainWindow() { DataContext = vm };
            mainWindow.Show();
        }
    }
