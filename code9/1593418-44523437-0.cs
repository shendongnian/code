    private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MyControl ctrl = d as MyControl;
        if (ctrl.IsLoaded)
        {
            //...
        }
    }
