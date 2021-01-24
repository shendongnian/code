    public bool delete(IEnumerable<long> paramIeId)
    {
        using(var nyDbContext = new DbContext())
        {
            foreach(long id in paramIeId)
            {
                MyType myType = nyDbContext.MyTypes.FirstOrDefault(x => x.ID == id);
                if (myType != null)
                {
                    nyDbContext.MyTypes.Remove(myType);
                }
            }
            nyDbContext.SaveChanges();
         }
    }
