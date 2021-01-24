    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.DataContextChanged += MainWindow_DataContextChanged;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GiveWindowHandleToViewModel();
        }
        private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GiveWindowHandleToViewModel();
        }
        private void GiveWindowHandleToViewModel()
        {
            // get view model
            var viewModel = this.DataContext as ViewModel;
            if (viewModel == null)
                return;
            // get window handle
            var windowHandle = this.GetWindowHandle();
            if (windowHandle == IntPtr.Zero)
                return;
            // signal view model
            viewModel.OnWindowHandleAvailable(windowHandle);
        }
        private IntPtr GetWindowHandle()
        {
            // get window
            var window = Window.GetWindow(this);
            if (window == null)
                return IntPtr.Zero;
            // get window handle
            return new WindowInteropHelper(window).Handle;
        }
    }
