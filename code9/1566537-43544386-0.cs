    static MyCustomControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl),
            new FrameworkPropertyMetadata(typeof(MyCustomControl)));
        IsEnabledProperty.OverrideMetadata(typeof(MyCustomControl),
            new FrameworkPropertyMetadata(IsEnabledPropertyChanged));
    }
    private static void IsEnabledPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        Debug.WriteLine("{0}.IsEnabled = {1}", obj, e.NewValue);
    }
