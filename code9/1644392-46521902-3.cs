    public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                ucOrder.Content = new ucOrderOversigt();            
                ucReports.Content = new ucReportOversigt();            
            }
    
            private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //if something needs to happend when you shift between tabs
            }
    
            private void Window_Closing(object sender, CancelEventArgs e)
            {
                //Window closing
            }
        }
