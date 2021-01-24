    private async void BtnProcess_OnClick(object sender, RoutedEventArgs e)
    {
        //Set the progress panel to visible
        toggleProgressPanel(true);
        //This is a long running process that can take 3-5 seconds.
        await ProcessRequest();
        //Hide the progress panel
        toggleProgressPanel(false);
    }
    private void toggleProgressPanel(bool show)
    {
        pnlProgressBar.Visibility = show ? Visibility.Visible : Visibility.Collapsed;
    }
    private async Task ProcessRequest()
    {
        await Task.Delay(50);
        //Now do all of my long running code here
    }
