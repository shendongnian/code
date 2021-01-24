    public static readonly BindableProperty ImageFileProperty =
            BindableProperty.Create("ImageFile", typeof(ImageSource), 
            typeof(CustomImageClass));
    public ImageSource ImageFile
    {
        get{ return (string)GetValue(ImageFileProperty); }
        set{ SetValue(ImageFileProperty, value); }
    }
