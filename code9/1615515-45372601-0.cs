      public partial class SampleWindow : Window
        {
            private bool _isButton1Enabled = false;
            public SampleWindow()
            {
                InitializeComponent();
            }
    
            private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                MessageBox.Show("Test");
            }
    
            private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
            {
                try
                {
                    e.CanExecute = _isButton1Enabled;
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
            
    
            private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
            {
                _isButton1Enabled = true;
                
            }
        }
