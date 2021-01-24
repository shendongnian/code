    public static object FooBar<T>(params object[] id)
    {
        using (var db = new DatabaseContext())
        {
            return db.Set<T>().Find(Id);
        }
    }
