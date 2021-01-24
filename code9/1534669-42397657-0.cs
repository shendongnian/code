    public static readonly DependencyProperty DateTimeValueProperty =
        DependencyProperty.Register(
            nameof(DateTimeValue),
            typeof(DateTime),
            typeof(DateTimeUserControl),
            new FrameworkPropertyMetadata(
                default(DateTime),
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                DateTimeValuePropertyChangedCallback));
    
