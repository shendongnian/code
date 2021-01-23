    public static T Copy<T>(T obj)
    {
        if (obj == null) throw new ArgumentNullException("obj");
        Type Typeobj = obj.GetType();
        var ResultObj = Activator.CreateInstance(Typeobj);
        Type ResultObjType = ResultObj.GetType();
        foreach (var field in Typeobj.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
        {
            FieldInfo f = ResultObjType.GetField(field.Name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            f.SetValue(ResultObj, field.GetValue(obj));
        }
        return (T) ResultObj;
    }
