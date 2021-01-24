    private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as ArticlesDetailControl;
        control.ForegroundElement.ChangeView(0, 0, 1);
        *** Update Binding ***
    }
