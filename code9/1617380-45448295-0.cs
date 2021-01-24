    [Category("MyCustomCategory")]
    public string MyCustomProperty
    {
    	get { return GetValue(MyCustomPropertyProperty).ToString(); }
    	set { SetValue(MyCustomPropertyProperty, value); }
    }
    public static DependencyProperty MyCustomPropertyProperty =
    	DependencyProperty
    	.Register(
    		"MyCustomProperty",
    		typeof(string),
    		typeof(MyCustomUserControl),
    		new PropertyMetadata("My default value")); // <--- default value
