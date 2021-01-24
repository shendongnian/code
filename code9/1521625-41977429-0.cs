    public static readonly DependencyProperty ContentProperty =
        DependencyProperty.Register(
            "Content",
            typeof(FrameworkElement),
            typeof(CustomControl1),
            new PropertyMetadata(null)
            {
                PropertyChangedCallback = OnContentChanged
            });
    private static void OnContentChanged(DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var control = (CustomControl1)d;
        if (e.OldValue != null)
            control.RemoveLogicalChild(e.OldValue);
        if (e.NewValue != null)
            control.AddLogicalChild(e.NewValue);
    }
