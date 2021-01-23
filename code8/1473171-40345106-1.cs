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
    }
    //  Since we're not going to be messing with cvsRS or cvsRS.View after the 
    //  constructor finishes, RSView can just be a plain getter. The value it returns 
    //  will never change. 
    public ICollectionView RSView
    {
        get { return cvsRS.View; }
    }
    
