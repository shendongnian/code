    public IEnumerable<ChildModel> Get()
    {
        db.Configuration.LazyLoadingEnabled = false;
        try
        {
            return db.ChildModels.Include("ParentModel").ToList();
        }
        finally
        {
            db.Configuration.LazyLoadingEnabled = true;
        }
    }
