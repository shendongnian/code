    public static readonly DependencyProperty ItemSourceProperty =
        DependencyProperty.Register(
            nameof(ItemSource), typeof(IEnumerable),
            typeof(DraggableItemsControlWithButtons));
    public IEnumerable ItemSource
    {
        get { return (IEnumerable)GetValue(ItemSourceProperty); }
        set { SetValue(ItemSourceProperty, value); }
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
