    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        if(MainFrame.CurrentSourcePageType == typeof(PageX))
        {
            MainFrame.BackStack.Clear();
            MainFrame.Navigate(typeof(PageY));               
        }
        else if (MainFrame.CanGoBack)
        {
            MainFrame.GoBack();
        }
        e.Handled = true;
    }
