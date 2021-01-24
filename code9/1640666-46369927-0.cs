    Task.Run(()=> 
    {
        Dispatcher dispatcher = Application.Current != null ?
            Application.Current.Dispatcher : Dispatcher.CurrentDispatcher;
        if (!dispatcher.CheckAccess())
        {
            dispatcher.Invoke(() =>
            {
                TextBox tb = new TextBox();
                Window window = new Window() { Content = tb };
                window.Activated += (ss, ee) => { /* ... */ };
                window.Loaded += (ss, ee) => tb.Focus();
                window.Topmost = true;
                if (window.ShowDialog() == true)
                {
                }
            });
        }
    });
