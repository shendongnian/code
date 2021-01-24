    public static List<T> GetList<T>(int anyParameters)
    {
        var results = new List<T>();
     var item = Activator.CreateInstance<T>();// Item here is the type of T
    // DO whatever processing is to be done on Item.
        results.Add(item);
    }
