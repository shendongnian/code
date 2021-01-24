    private TDelegate CreateCallback<TDelegate>(Type actionType, string method)
        where TDelegate : class
    {
        if (!typeof(Delegate).IsAssignableFrom(typeof(TDelegate)))
        {
            throw new InvalidOperationException("Card::SetupCallback - " + typeof(TDelegate).Name + " is not a delegate");
        }
        MethodInfo methodInfo = actionType.GetMethod(method);
        
        if (methodInfo != null)
        {
            // the following line will also validate compatibility of delegate types
            Delegate nonTypedDelegate =  methodInfo.CreateDelegate(typeof(TDelegate));
            TDelegate typedDelegate = (TDelegate)(object)nonTypedDelegate;
            return typedDelegate;
        }            
        return null;
    }
