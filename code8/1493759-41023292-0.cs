    public static ExpandoObject Extend<T>(this T obj)
    {
        dynamic eo = new ExpandoObject();
        var props = eo as IDictionary<string, object>;
        PropertyInfo[] pinfo = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (PropertyInfo p in pinfo)
            props.Add(p.Name, p.GetValue(obj));
        //If you need to add some property known at compile time
        //you can do it like this:
        eo.SomeExtension = "Some Value";
        return eo;
    }
