    public static bool GetProp(object obj, string propName, string value)
    {
        object o = obj.GetType().GetProperty(propName).GetValue(obj);
        IQueryable<object> queryable = o as IQueryable<object>;
        if (queryable != null)
        {
            return queryable.Contains(value);
        }
        return false; //Some other default
    }
