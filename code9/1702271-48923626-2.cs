    public static readonly DependencyProperty FillProperty =
       Shape.FillProperty.AddOwner(typeof(CustomShape));
    public Brush Fill
    {
        get { return (Brush)GetValue(FillProperty); }
        set { SetValue(FillProperty, value); }
    }
