    public static readonly DependencyProperty StartAngleX1Property =
        DependencyProperty.Register(
            "StartAngleX1",
            typeof(double),
            typeof(MyUserControl),
            new PropertyMetadata(0.0));
    public double StartAngleX1
    {
        get { return (double)GetValue(StartAngleX1Property); }
        set { SetValue(StartAngleX1Property, value); }
    }
