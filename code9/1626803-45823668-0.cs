    void Copy(object from, object to)
    {
        Type fromType = from.GetType();
        Type toType = to.GetType();
        foreach(var prop in fromType.GetProperties()
                                    .Where(p=>toType.GetProperty(p.Name)!=null))
        {
            toType.GetProperty(prop.Name).SetValue(to, prop.GetValue(from, null));
        }
    }
