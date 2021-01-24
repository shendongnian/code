    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Task.Run(() =>
            {
                throw new Exception("test");
            });
            Loaded += (s, e) => 
            {
                //gc so the unobserved exception "bubbles" up
                GC.Collect(3, GCCollectionMode.Forced, true);
            };
        }
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            MessageBox.Show(ex.Message, "Uncaught Thread Exception",
                            MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
