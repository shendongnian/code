    private void Back_Button_Click(object sender, RoutedEventArgs e)
    {
        if (SubPageFrame.CanGoBack)
        {
            var backstack = SubPageFrame.BackStack;
            if (backstack.Count > 1)
            {
                SubPageFrame.GoBack();
            }
            else
            {
                SubPageFrame.BackStack.Clear();
                SubPageFrame.Visibility = Visibility.Collapsed;
                BasicContentScrollViewer.Visibility = Visibility.Visible;
            }
        }
        else
        {
            SubPageFrame.Visibility = Visibility.Collapsed;
            BasicContentScrollViewer.Visibility = Visibility.Visible;
        }
    }
