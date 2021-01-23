    public static readonly DependencyProperty TestProperty =
        DependencyProperty.Register(
            "Test", typeof(string), typeof(MyControl), new PropertyMetadata("DEFAULT"));
    public string Test
    {
        get { return (string)GetValue(TestProperty); }
        set { SetValue(TestProperty, value); }
    }
