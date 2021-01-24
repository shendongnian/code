    public static readonly DependencyProperty InnerContentProperty = DependencyProperty.Register(nameof(InnerContent), typeof(UIElement), typeof(YourCustomControl));
    
    public UIElement InnerContent
    {
        get => (UIElement)GetValue(InnerContentProperty);
        set => SetValue(InnerContentProperty, value);
    }
