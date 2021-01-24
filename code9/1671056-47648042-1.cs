    public void UpdateUI(object parameter)
    {
        if (!Dispatcher.CheckAccess())
        {
           Dispatcher.BeginInvoke(new Action(() => UpdateUI(parameter)));
           return;
        }
    
        // Do update or access here
    }
