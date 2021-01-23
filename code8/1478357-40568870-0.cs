    public IEnumerable Items
    {
        get { return (IEnumerable)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
    public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(IEnumerable), typeof(ParameterListControl), new PropertyMetadata(new List<object>()));
