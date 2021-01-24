    public static BindableProperty MyProperty = BindableProperty.Create("propertyName", typeof(ImageGallery), typeof(IList), default(IList), BindingMode.TwoWay,
        propertyChanging: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanging();
        },
        propertyChanged: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanged(bindableObject, oldValue, newValue);
        });
