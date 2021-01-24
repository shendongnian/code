    public IList Map
    {
        get { return (IList)GetValue(MapProperty); }
        set { SetValue(MapProperty, value); }
    }
    public static readonly DependencyProperty MapProperty =
        DependencyProperty.Register("Map", typeof(IList),
            typeof(MyConverter), new PropertyMetadata(new List<object>()));
