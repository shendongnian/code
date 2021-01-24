    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        //do something with the secondary view's UI
        //this code now runs on the secondary view's thread
        //Window.Current here refers to the secondary view's Window
        //the following example changes the background color of the page
        var frame = ( Frame )Window.Current.Content;
        var detail = ( Detail )frame.Content;
        var grid = ( Grid )detail.Content;
        grid.Background = new SolidColorBrush(Colors.Red);
    }
    
