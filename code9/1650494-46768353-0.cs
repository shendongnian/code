    private void element_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        ((MediaElement)sender).Pause();
    }
    private void element_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
    {
        ((MediaElement)sender).Pause();
    }
