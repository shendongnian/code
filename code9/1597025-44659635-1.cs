    public object Text
    {
        get => (object)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(object), typeof(MyButton));
