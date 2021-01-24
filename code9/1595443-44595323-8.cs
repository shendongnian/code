    private Func<object> GetDelegateFromMethodName(object instance, string methodName)
    {
        var type = instance.GetType();
        var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);
        if (method == null)
        {
            throw new ArgumentException(nameof(methodName));
        }
        return (Func<object>) Delegate.CreateDelegate(typeof(Func<object>), instance, method);
    }
    private Func<object> GetDelegateFromMethodName(Type type, string methodName)
    {
        var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);
        if (method == null)
        {
            throw new ArgumentException(nameof(methodName));
        }
        return (Func<object>)Delegate.CreateDelegate(typeof(Func<object>), method);
    }
