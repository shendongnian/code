    public static readonly DependencyProperty InternalCurrentItemProperty =
            DependencyProperty.Register("InternalCurrentItem", typeof(CityEntity), typeof(CustomAutoCompleteBox),
                new FrameworkPropertyMetadata(
                    null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    
    public CityEntity InternalCurrentItem
    {
        get{ return (CityEntity)GetValue(InternalCurrentItemProperty); }
    
        set
        {
            SetValue(InternalCurrentItemProperty, value);
        }
    }
