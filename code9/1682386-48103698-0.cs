    public Test MyData
    {
        get { return (Test)GetValue(MyDataProperty); }
        set { SetValue(MyDataProperty, value); }
    }
    public static readonly DependencyProperty MyDataProperty =
        DependencyProperty.Register("MyData", typeof(Test), typeof(TestControl), new PropertyMetadata(null));
