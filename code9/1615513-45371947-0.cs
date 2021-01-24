    public partial class MainWindow : Window {
    
        // other details elided
        bool _enableButton1 = false;
    
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = _enableButton1;
        }
    
        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e) {
            enableButton1 = true;
        }
    }
    
