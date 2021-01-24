    using System.Reflection;
    /*...*/
    public static object ToDynamicDisplayName(object input)
    {
        var type = input.GetType();
        dynamic dObject = new ExpandoObject();
        var dDict = (IDictionary<string, object>)dObject;
    
        foreach (var p in type.GetProperties())
        {
            var prop = type.GetProperty(p.Name);
            var displayNameAttr = p.GetCustomAttribute<DisplayNameAttribute>(false);
            if (prop == null || prop.GetIndexParameters().Length != 0) continue;
            if (displayNameAttr != null)
            {
                dDict[displayNameAttr.DisplayName] = prop.GetValue(input, null);
            }
            else
                dDict[p.Name] = prop.GetValue(input, null);
        }
        return dObject;
    }
