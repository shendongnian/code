    private void Current_Activated(object sender, WindowActivatedEventArgs e)
    {
        if (e.WindowActivationState != CoreWindowActivationState.Deactivated)
        {
            BackButtonGrid.Visibility = Visibility.Visible;
            MainTitleBar.Opacity = 1;
        }
        else
        {
            BackButtonGrid.Visibility = Visibility.Collapsed;
            MainTitleBar.Opacity = 0.5;
        }
    }
