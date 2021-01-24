    public partial class MainWindow : Window
    {
        //Flag indicating async operation is in progress
        private bool m_EventHandlerIsRunning = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        // Subscribe this method to MainWindow's Closing event
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Forbid MainWindow to close, if async event handler is running
            e.Cancel = m_EventHandlerIsRunning;
        }
        // You will have to include following in all async event handlers
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Forbid MainWindow to be closed
                m_EventHandlerIsRunning = true;
                // Do something async 
                await Task.Delay(1000);
            }
            finally
            {
                // Let MainWindow to be closed
                m_EventHandlerIsRunning = false;
            }
        }
    }
