    public static DateTime GetExpirationDate<T>(long id) 
            where T : class, IExpirationDate
    {
        using(var db = new myContext())
        {
            var entry = db.Set<T>.Find(id);
            return entry.ExpirationDate;
        }
    }
