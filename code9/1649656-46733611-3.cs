    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var propertyInfo = item.GetType().GetProperty(myCollectionPropertyName);
        var propertyValue = propertyInfo.GetValue(item);
        var incc = propertyValue as INotifyCollectionChanged;
    
        incc.CollectionChanged += yGenericChangeEvent;
