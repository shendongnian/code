    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.window = window;
            window.DataContext = viewModel;
            window.Show();
            App.Current.MainWindow = window;
        }
    }
