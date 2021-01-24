    public virtual Menu FindBy(Expression<Func<Menu, bool>> query)
    {
        return NHUnitOfWork.Session.Query<Menu>().Where(query)
            .FetchMany(m => m.Rights)
            // Required with FetchMany and First, otherwise only one right would be loaded.
            .ToList()
            .FirstOrDefault();
    }
