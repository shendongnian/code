    public class MainWindowVM
    {
        private MainWindow mainWindow;
        public delegate void EventWithoudArg();
        public event EventWithoudArg Closed;
        
        public MainWindowVM()
        {
            mainWindow = new MainWindow();
            mainWindow.Closed += MainWindow_Closed;
            mainWindow.DataContext = this;
            mainWindow.Loaded += MainWindow_Loaded;
            mainWindow.Closing += MainWindow_Closing;
            mainWindow.Show();
        }
        private void MainWindow_Loaded()
        {
            //your code
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //your code
        }
        private void MainWindow_Closed()
        {
            Closed?.Invoke();
        }
    }
