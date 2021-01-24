    void Main()
    {
        var a = new A();
        var type = a.GetType();
        var delegateProperty = type
            .GetProperties()
            .First(property => property.PropertyType.IsSubclassOf(typeof(Delegate)));
        delegateProperty.SetValue(a, (Action)(() => Console.WriteLine("via reflection")));
        
        a.Action();
    }
