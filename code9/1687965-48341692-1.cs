    private int n;
    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (n++ > 0)
        {
            var ctrl = d as Window29;
            bool newValue = (bool)e.NewValue;
            //...
        }
    }
