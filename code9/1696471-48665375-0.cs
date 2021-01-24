    public static BindableProperty MyProperty = BindableProperty.Create(view => view.ItemsSource, default(IList), BindingMode.TwoWay,
        typeof(ImageGallery), typeof(IList),
        propertyChanging: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanging();
        },
        propertyChanged: (bindableObject, oldValue, newValue) => 
        {
            ((ImageGallery) bindableObject).ItemsSourceChanged(bindableObject, oldValue, newValue);
        });
