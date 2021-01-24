    public ICollectionView CompanyItemCollectionView
    {
        get
        {            
            return new CollectionViewSource { Source = CompanyItems }.View;
        }
    } 
