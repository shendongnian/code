    public static T operator ?.(Nullable<U> lhs, Func<U,T> rhs) 
        where T: class
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
