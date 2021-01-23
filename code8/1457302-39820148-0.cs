    if (this.Dispatcher.CheckAccess())
    {
        this.RootGrid.Children.Add(obj);
    }
    else
    {
        this.Dispatcher.Invoke(delegate () { afficherimage(obj); });
    }
