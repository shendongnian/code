    public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MultiLineButton), 12d);
    
    [TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }
