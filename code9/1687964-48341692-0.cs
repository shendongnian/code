    public static readonly DependencyProperty NeedToDrawRectProperty = DependencyProperty.Register(nameof(NeedToDrawRect),
        typeof(bool), typeof(PanZoomImage ), new PropertyMetadata(new PropertyChangedCallback(OnValueChanged)));
    public bool NeedToDrawRect
    {
        get { return (bool)GetValue(NeedToDrawRectProperty); }
        set { SetValue(NeedToDrawRectProperty, value); }
    }
    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var ctrl = d as PanZoomImage;
        bool newValue = (bool)e.NewValue;
        //...
    }
