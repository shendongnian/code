    public static BindableProperty ParentBindingContextProperty = 
        BindableProperty.Create(nameof(ParentBindingContext), typeof(object), 
        typeof(CircleView), null);
    public object ParentBindingContext
    {
        get { return GetValue(ParentBindingContextProperty); }
        set { SetValue(ParentBindingContextProperty, value); }
    }
