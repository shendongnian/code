    public MyViewModel()
    {
        BindCollectionViewSource();
    }
    protected void BindCollectionViewSource()
    {
        cvsRS = new CollectionViewSource();
        var binding = new Binding
        {
            Source = this,
            Path = new PropertyPath("RS")
        };
        BindingOperations.SetBinding(cvsRS, CollectionViewSource.SourceProperty, binding);
        //  cvsRS won't have a View until after you bind Source to a collection.
        RSView = cvsRS.View;
    }
