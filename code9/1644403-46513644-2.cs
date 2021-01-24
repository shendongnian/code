    public static readonly DependencyProperty LeftImageProperty =
        DependencyProperty.Register(
            nameof(LeftImage), typeof(ImageSource), typeof(actionButton));
    public ImageSource LeftImage
    {
        get { return (ImageSource)GetValue(LeftImageProperty); }
        set { SetValue(LeftImageProperty, value); }
    }
