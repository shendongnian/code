    public static readonly BindableProperty TypeProperty = BindableProperty.CreateAttached("TypeElement", typeof(string), typeof(UserView), "default value", propertyChanged:OnTypeElementChanged);
    
    private static void OnTypeElementChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var userView = bindable as UserView;
        StackLayout stackLayout = new StackLayout();
        if (userView.TypeElement == "label")                              //TypeElement return only "default value"
            stackLayout.Children.Add(new Label { Text = "LABEL" });
        else
            stackLayout.Children.Add(new Entry { Text = "ENTRY" });
    
        userView.Content = stackLayout;
    }
