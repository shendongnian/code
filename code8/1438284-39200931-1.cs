    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        if (size != null)
        {
            var newwidth = Convert.ToInt32(size[0]) - 300;
            var newheight = Convert.ToInt32(size[1]) - 200;
            ApplicationView.GetForCurrentView().TryResizeView(new Size { Width = newwidth, Height = newwidth });
        }
    }
    
    private string[] size;
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    
    {
        if (e.Parameter.ToString() != "")
        {
            size = e.Parameter.ToString().Split(':');
        }
    }
