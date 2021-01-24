    using (myContext)
    {
        var existingMyTypes = nyDbContext.MyTypes.Where(x => paramIeId.Contains(x.ID));
        foreach (MyType existing in existingMyTypes)
        {
            nyDbContext.Remove(existing);
        }
        nyDbContext.SaveChanges();
    }
