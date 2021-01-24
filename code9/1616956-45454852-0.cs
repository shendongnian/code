    private void ContactsView_DataContextChanged(FrameworkElement sender, 
    DataContextChangedEventArgs args)
            {
                var viewModel = DataContext as ContactsViewModel;
                if (viewModel == null) return;
                viewModel.RingtoneElement = RingtoneElement;
    
    
    
                //adding the following if block solved the bug
                if (_isFirstNavigation)
                {
                    viewModel.ShowSettings.Execute(null);
                    _isFirstNavigation = false;
                }
            }
 
