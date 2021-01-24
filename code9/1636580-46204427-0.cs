    static Type MakeGenericType(Type definition, Type parameter)
    {
    	var definitionStack = new Stack<Type>();
    	var type = definition;
    	while (!type.IsGenericTypeDefinition)
    	{
    		definitionStack.Push(type.GetGenericTypeDefinition());
    		type = type.GetGenericArguments()[0];
    	}
    	type = type.MakeGenericType(parameter);
    	while (definitionStack.Count > 0)
    		type = definitionStack.Pop().MakeGenericType(type);
    	return type;
    }
