    public static int GetRowCount<T>(DbContext DatabaseContext, DbSet<T> TableEntity)
    {
        var countVal = TableEntity.Count();
        return countVal;
    }
