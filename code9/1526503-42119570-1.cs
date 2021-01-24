    public partial class App : Application {
        private void OnAppStartup(object sender, StartupEventArgs e) {                        
            Application.Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            var vm = new PayslipModel();
            var mainWindow = new MainWindow(vm);
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
