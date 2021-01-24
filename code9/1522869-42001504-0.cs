    public static List<T> ConstructItemDatabase<T>(List<T> list, string fileLocation) where T : new()
    {
        // add new Item
        list.Add(new T());
        // if you need a list of all the properties:
        PropertyInfo [] allProperties = typeof(T).GetProperties();
       
        return list;
    }
