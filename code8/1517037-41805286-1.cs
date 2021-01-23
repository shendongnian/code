    var windows = Application.Current.Windows;
    foreach(var window in windows)
    {
        var buttons = FindVisualChildren<Buttons>(window);
        if(buttons != null)
        {
            foreach(var button in buttons)
            {
                bool isEnabled = buttons.IsEnabled;
                //...
            }
        }
    }
