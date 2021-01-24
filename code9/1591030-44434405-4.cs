    public static readonly DependencyProperty ButtonImageProperty
        = DependencyProperty.Register(
            "ButtonImage", 
            typeof(ImageSource), 
            //  Should be ButtonSmall, not TextOutput
            typeof(ButtonSmall), 
            new PropertyMetadata(null));
