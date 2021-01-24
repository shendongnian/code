    int Call(Type classType)
    {
       var xvalue = (int)classType.GetProperty("x", BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
       var yvalue = (int)classType.GetProperty("y", BindingFlags.Public | BindingFlags.Static).GetValue(null, null);
    }
