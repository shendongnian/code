    public string Value
    {
        get { return (string)GetValue(ValueProperty); }
        set { SetValue(ValueProperty, value); }
    }
    public static readonly DependencyProperty ValueProperty =
        DependencyProperty.Register("Value", typeof(string), typeof(UserControl ), new PropertyMetadata(""));
