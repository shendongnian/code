    public List<Case> GetCases()
    {
        db.Configuration.ProxyCreationEnabled = false;
        return db.Cases.AsNoTracking().ToList();
    }
