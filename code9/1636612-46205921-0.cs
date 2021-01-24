    var metadata = new FrameworkPropertyMetadata( "", OnValueChanged, null, null)
    return DependencyProperty.Register(propertyName, typeof(object), 
                                       typeof(CustomButton), metadata)
    private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
      ;
    }
