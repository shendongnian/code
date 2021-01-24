    public static readonly DependencyProperty ButtonImageSourceProperty
        = DependencyProperty.Register(
            "ButtonImageSource", 
            typeof(ImageSource), 
            //  Should be ButtonSmall, not TextOutput
            typeof(ButtonSmall), 
            new PropertyMetadata(null));
    public ImageSource ButtonImageSource
    {
        get { return (ImageSource)GetValue(ButtonImageSourceProperty); }
        set { SetValue(ButtonImageSourceProperty, value); }
    }
