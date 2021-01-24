    Type type = ...
    if(type.IsSubclassOf(typeof(Delegate)))
    {
        var method = type.GetMethod("Invoke");
        foreach(var arg in method.GetParameters())
        {
            Console.WriteLine(arg.Name + ": " + arg.ParameterType.ToString());
        }
        Console.WriteLine("returns: " + method.ReturnType.ToString())
    }
