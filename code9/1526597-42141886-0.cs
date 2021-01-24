    public static readonly BindableProperty ItemTemplateProperty =
    	BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CarouselLayout ), default(DataTemplate));
    
    public DataTemplate ItemTemplate
    {
    	get { return (DataTemplate)GetValue(ItemTemplateProperty); }
    	set { SetValue(ItemTemplateProperty, value); }
    }
