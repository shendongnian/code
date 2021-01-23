    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponents();
            this.DataContext = new MainViewModel();
        }
    }
