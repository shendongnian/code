    private static void SaveMethods(TypeDefinition typeDef, IEnumerable<string> names)
    {
    	var pos = 0;
    	while (true)
    	{
    		if (pos == typeDef.Methods.Count)
    			break;
    
    		var md = typeDef.Methods[pos];
    
    		// save ctors, method implementations and explicit interface implementations
    		if (md.Name == ".ctor" ||
    			names.Contains(md.Name) ||
    			(md.Overrides.Count > 0 && names.Contains(md.Overrides[0].Name)))
    		{
    			pos++;
    		}
    		else
    		{
    			typeDef.Methods.RemoveAt(pos);
    		}
    	}
    }
    
