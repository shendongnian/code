    public static MyUserControl GetControlByTag(this Page page, int tag) {
        Grid rootGrid = page.Content as Grid;
        if(page.Dispatcher.HasThreadAccess) {
            //Code to run
        }
        else {
            page.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                //Code to run
            }).AsTask().Wait();
        }
    }
