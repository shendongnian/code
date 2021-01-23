    public Delegate DoCallMyMethod(object target, Type inputType)
    {
        var @interface = typeof(IMyTest<>).MakeGenericType(inputType);
        if (@interface.IsAssignableFrom(target.GetType()))
        {
            var method = @interface.GetMethod("MyMethod");
            if (method != null)
            {
                var @delegate = Delegate.CreateDelegate(typeof(Action<>).MakeGenericType(inputType), target, method);
                return @delegate;
            }
        }
        return null;
    }
