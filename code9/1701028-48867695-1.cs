    var types = GetType().Assembly.GetTypes()
                                            .Where(type => type.IsSubclassOf(typeof(CodedCommand)) && !type.IsAbstract);
    
    foreach (var type in types)
    {
    	var obj = Activator.CreateInstance(type);
    	var field = type.GetProperty("Code", BindingFlags.Instance | BindingFlags.NonPublic);
    	var value = field.GetValue(obj);
    	var code = (char)value;
    
    	_typeMap[code] = type;
    }
