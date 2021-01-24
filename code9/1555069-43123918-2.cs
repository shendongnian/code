    var parameters = new List<object>();
    foreach (var param in ctor.GetParameters())
    {
        var obj = Activator.CreateInstance(param.ParameterType);
        parameters.Add(obj);
    }
    var myClassObj = Activator.CreateInstance(typeof(MyClass), parameters.ToArray());
