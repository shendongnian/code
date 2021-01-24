    public DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        var incc = (INotifyCollectionChanged)item.GetType()
            .GetProperty(myCollectionPropertyName).GetValue(item);
        incc.CollectionChanged += yGenericChangeEvent;
