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
            mainWindow.Show();
        }
        private void MainWindow_Closed()
        {
            Closed?.Invoke();
        }
    }
