    private static void UserAcccessnChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement frameworkElement = (FrameworkElement)d;
        Dictionary<string, UserConfiguration> myDict = 
            (Dictionary<string, UserConfiguration>)e.NewValue;
        UserConfiguration uc = myDict[frameworkElement.Name];
