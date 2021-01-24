    private int n;
    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (n++ > 0)
        {
            var ctrl = (PanZoomImage)d;
            var newValue = (bool)e.NewValue;
            //...
        }
    }
