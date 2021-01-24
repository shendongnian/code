    public static List<T2> ConvertList<T1, T2>(List<T1> param) 
                     where T1:class,T2 
                     where T2:class
    {
        List<T2> result = new List<T2>();
    
        foreach (T1 p in param)
            result.Add((T2)p);
    
        return result;
    }
