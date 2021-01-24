     public static BindableProperty TextChangedProperty = BindableProperty.Create(nameof(TextChanged), typeof(string), typeof(YourView), string.Empty,  propertyChanged:OnTextChanged);
    
     public string TextChanged
     {
         get { return (string)GetValue(TextChangedProperty); }
         set { SetValue(TextChangedProperty, value); }
     }
    
     static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
     {
        //Do stuff
     }
