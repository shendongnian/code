    public static DependencyProperty TestProperty = DependencyProperty.Register(
    "Test",
    typeof(double),
    typeof(TestPanel),
    new FrameworkPropertyMetadata(
       0.0,
       OnPropertyChanged));
    private static object OnPropertyChanged(DependencyObject d, object baseValue)
    {
        //...
    }
