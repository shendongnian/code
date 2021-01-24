     private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;
        var workingArea = System.Windows.SystemParameters.WorkArea;
        this.Left = 0;
        this.Top = workingArea.Bottom - this.Height;
    }
