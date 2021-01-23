    public static MyUserControl GetControlByTag(this Page page, int tag) {
        MyUserControl rtn = null; 
        page.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
            Grid rootGrid = page.Content as Grid;
            if(rootGrid != null) {
                var controls = rootGrid.Children.OfType<MyUserControl>();
                foreach(MyUserControl control in controls)
                {
                    if(control.Tag == tag) rtn = control;
                }
            }
        }).AsTask().Wait(); //Runs the dispatcher synchronously
        return rtn;
    }
