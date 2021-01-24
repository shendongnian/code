    public ImageSource Image
            {
                get { return (ImageSource)GetValue(ImageProperty); }
                set { SetValue(ImageProperty, value); }
            }
           public static readonly DependencyProperty ImageProperty =
                DependencyProperty.Register("Image", typeof(ImageSource), typeof(CustomControl), 
                    new FrameworkPropertyMetadata(default(ImageSource), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
            public ImageSource NewImage
            {
                get { return (ImageSource)GetValue(NewImageProperty); }
                set { SetValue(NewImageProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for NewImage.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty NewImageProperty =
                DependencyProperty.Register("NewImage", typeof(ImageSource), typeof(CustomControl),
                     new FrameworkPropertyMetadata(default(ImageSource), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
