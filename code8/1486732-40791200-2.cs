    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register(
            nameof(ItemsSource), typeof(IEnumerable),
            typeof(DraggableItemsControlWithButtons));
    public IEnumerable ItemsSource
    {
        get { return (IEnumerable)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
    public static readonly DependencyProperty ItemTemplateProperty =
        DependencyProperty.Register(
            nameof(ItemTemplate), typeof(DataTemplate),
            typeof(DraggableItemsControlWithButtons));
    public DataTemplate ItemTemplate
    {
        get { return (DataTemplate)GetValue(ItemSourceProperty); }
        set { SetValue(ItemSourceProperty, value); }
    }
