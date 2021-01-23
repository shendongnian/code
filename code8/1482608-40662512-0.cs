    public static readonly DependencyProperty ControllerStatusProperty =
        DependencyProperty.RegisterAttached(
            "ControllerStatus",
            typeof(string),
            typeof(ControllerAttachedProp),
            new PropertyMetadata(string.Empty));
