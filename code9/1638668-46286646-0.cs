    public dynamic FindEntity(string table, long Id)
    {
        PropertyInfo prop = this.GetType().GetProperty(table, BindingFlags.Instance | BindingFlags.Public);
        dynamic dbSet =  prop.GetValue(this, null);
        return dbSet.Find(Id);
    }
