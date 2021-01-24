    public ImageGallery MyImageGallery
    {
    	get { return (ImageGallery)GetValue(MyImageGalleryProperty); }
    	set { SetValue(MyImageGalleryProperty, value); }
    }
    public static BindableProperty MyImageGalleryProperty = BindableProperty.Create(nameof(MyImageGallery), typeof(ImageGallery), typeof(IList), default(IList), BindingMode.TwoWay,
        propertyChanging: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanging();
        },
        propertyChanged: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanged(bindableObject, oldValue, newValue);
        });
