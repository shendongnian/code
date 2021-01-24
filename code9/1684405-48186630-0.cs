    public IQueryable<IModelBaseIndexItem> ReadIndex()
    {
        try
        {
            Type TIndexItem = typeof(T).Assembly.GetType(typeof(T).FullName + "IndexItem");
            return (IQueryable<IModelBaseIndexItem>) db.Set(TIndexItem);
        }
        catch (Exception)
        {
            throw new IRepositoryException();
        }
    }
