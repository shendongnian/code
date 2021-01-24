    public static T Next<T>(T currentElement, Expression<Func<T, object>> navigationProperty) where T : class, IModel
    {
        T data;
        if (currentElement.Id >= GetLastId<T>())
            return currentElement;
        using (DatabaseEntities context = new DatabaseEntities())
        {
            IQueryable<T> dbQuery = context.Set<T>();
            if (navigationProperty != null)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);
            data = dbQuery.AsNoTracking().Single(el => el.Id == currentElement.Id + 1);
        }
        return data;
    }
