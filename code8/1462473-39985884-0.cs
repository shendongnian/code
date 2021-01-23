    Type t = collection.GetType();
    MethodInfo add = t.GetMethod("Add");
    if (add != null)
    {
        params = new object[] { item };
        add.Invoke(collection, params);
    }
