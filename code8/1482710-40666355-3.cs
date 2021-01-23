    public static T operator ?.(Nullable<U> lhs, Func<U,T> rhs) 
        where T: class
        where U: struct
    {
        if(lhs.HasValue)
        {
            return rhs(lhs.Value);
        }
        else 
        {
            return default(T);
        }
    }
