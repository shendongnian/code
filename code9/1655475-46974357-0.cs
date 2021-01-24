    public override void WriteJson<T>(JsonWriter writer, Tvalue, JsonSerializer serializer)
    {
        var pagedList = (IPagedList<T>)value;
    }
    var obj = ...
    var m = typeof(MyClass).GetMethod("WriteJson").MakeGenericMethod(obj.GetType());
    m.Invoke(instanceOfMyClass, new object[] { myWriter, obj, myerializer });
