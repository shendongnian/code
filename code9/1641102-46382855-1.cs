    private void changes(object sender, SelectionChangedEventArgs e)
    {
        if (tab1.IsSelected)
        {
            VisualStateManager.GoToElementState(window, "Big", true);
        }
        else
        {
            VisualStateManager.GoToElementState(window, "Small", true);
        }
    }
