    public string UriPath
    {
        get => (string)GetValue(UriPathProperty);
        set => SetValue(UriPathProperty, value);
    }
    public static readonly DependencyProperty UriPathProperty = DependencyProperty.Register(
        "UriPath", typeof(string), typeof(ImageControl), new PropertyMetadata(default(string)));     
    
    public double Angle
    {
        get => (double)GetValue(AngleProperty);
        set => SetValue(AngleProperty, value);
    }
    public static readonly DependencyProperty AngleProperty = DependencyProperty.Register(
        "Angle", typeof(double), typeof(ImageControl), new PropertyMetadata(default(double)));
    
    public BitmapImage ConvertToBitmapImage(string path) => new BitmapImage(new Uri(BaseUri, path));
