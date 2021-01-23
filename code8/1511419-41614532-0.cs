    public static readonly DependencyProperty YourWidthProperty =
         DependencyProperty.Register("YourWidth", typeof(double),
         typeof(MyClass), new FrameworkPropertyMetadata(0.0));
    public double YourWidth
    {
        get { return (double)GetValue(YourWidthProperty); }
        set { SetValue(YourWidthProperty, value); }
    }
