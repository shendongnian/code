    public void CallProxyMethod()
    {
        var withHelperMethod = new SomeProxyClass()
        {
            Quotes.DoubleQuotes("parameter1", "parameter2"),
            Quotes.DoubleQuotes("parameter3")
        };
        var withoutHelperMethod = new SomeProxyClass()
        {
            new StringBuilder("\"parameter1\""),
            new StringBuilder("\"parameter2\""),
        };
            
        SomeProxyMethod(withHelperMethod);
        SomeProxyMethod(withoutHelperMethod);
    }
