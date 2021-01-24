    public static readonly DependencyProperty MyCustomLabelContentProperty = 
        DependencyProperty.Register(
            "MyCustomLabelContent",
            typeof(string),
            typeof(DPControl),
            new FrameworkPropertyMetadata(null, 
                FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );
