    void Main()
    {
        var a = new A();
        var type = a.GetType();
        
        var delegateProperty = type.GetProperty(nameof(A.Action));
        delegateProperty.SetValue(a, (Action)(() => Console.WriteLine("via reflection")));
        
        a.Action();
    }
