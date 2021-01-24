    [ViewToViewModel(MappingType = ViewToViewModelMappingType.ViewToViewModel)]
    public SuggestedEntityType EntityType
    {
        get { return (SuggestedEntityType) GetValue(EntityTypeProperty); }
        set { SetValue(EntityTypeProperty, value); }
    }
 
    public static readonly DependencyProperty EntityTypeProperty = DependencyProperty.Register("EntityType", typeof (SuggestedEntityType),
        typeof (MyControl), new PropertyMetadata(null));
