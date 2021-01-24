    var t = typeof(BaseTest<int>);
    
    if (t.GetType().IsGenericType &&
        t.GetType().GetGenericTypeDefinition() == typeof(BaseTest<>))
    {
    	var type = t.GetGenericArguments()[0];
    }
