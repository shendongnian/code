    public virtual Menu FindBy(Expression<Func<Menu, bool>> query)
    {
        return NHUnitOfWork.Session.Query<Menu>().Where(query)
            .Fetch(m => m.Right)
            .FirstOrDefault();
    }
