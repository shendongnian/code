    public static readonly BindableProperty ItemsSourceProperty = 
    BindableProperty.Create("ItemsSource", ..., propertyChanged: OnItemsSourceChanged);
    static void OnEventNameChanged (BindableObject bindable, object oldValue, object newValue)
    {
        // Property changed implementation goes here
    }
