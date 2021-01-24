        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            MainView.SelectedIndex = 1;
            MainView.SelectionChanged += MainView_SelectionChanged;
        }
        private void MainView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainView.SelectedIndex == 0)
            {
                //perform the action for Back Swipe Gesture
                changeDisplayedMonth(-1);
                //force selection back to our content FlipViewItem
                MainView.SelectedIndex = 1;               
            }
            if (MainView.SelectedIndex == 2)
            {
                //perform the action for Forward Swipe Gesture 
                changeDisplayedMonth(1);
                //force selection back to our content FlipViewItem               
                MainView.SelectedIndex = 1;                
            }            
        }
