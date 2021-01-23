    private readonly Dictionary<MyEnum, Type> _Data;
    public Factory(Assembly assembly) 
    {
        var myAttributeClasses = 
            assembly.GetTypes()
                    .Select(t => new 
                    {
                        DirevedType = t,
                        Attribute = (MyAttribute)t.GetCustomAttribute(typeof(MyAttribute))
                    })
                    .Where(data => data.Attribute != null);
                
        _Data = new Dictionary<MyEnum, Type>();
        foreach(var data in myAttributeClasses)
        {
            _Data.Add(data.Attribute.EnumValue, data.DerivedType);
        }
    }
    public MyMain CreateInstance(MyEnum enumvalue)
    {
        Type derivedType;
        if(_Data.TryGetValue(enumvalue, out derivedType) == false) 
            return null;
    
        return Activator.CreateInstance(derivedType);
    }
