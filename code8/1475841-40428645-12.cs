    public Action<object> DoCallMyMethod(object target, Type inputType)
    {
        var @interface = typeof(IMyTest<>).MakeGenericType(inputType);
        if (@interface.IsAssignableFrom(target.GetType()))
        {
            var method = @interface.GetMethod("MyMethod");
            if (method != null)
            {
                Action<object> action = obj =>
                {
                    if (obj.GetType().IsAssignableFrom(inputType))
                        method.Invoke(target, new object[] { obj });
                };
                return action;
            }
        }
        return null;
    }
