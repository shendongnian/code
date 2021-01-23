    public Action<T> DoCallMyMethod<T>(object target)
    {
        var @interface = typeof(IMyTest<T>);
        if (@interface.IsAssignableFrom(target.GetType()))
        {
            var method = @interface.GetMethod("MyMethod");
            if (method != null)
            {
                var action = Delegate.CreateDelegate(typeof(Action<T>), target, method) as Action<T>;                    
                return action;
            }
        }
        
        return null;
    }
