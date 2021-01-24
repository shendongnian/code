    var myTypes = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);
    myTypes.Add("Leia", typeof(User));
    ...
    if (!myTypes.ContainsKey(key))
    {
    	Console.WriteLine($"Dictionary failed to contain the key: {key}");
    	return;
    }
    
    var myType = myTypes[key];
    Console.WriteLine($"Found the type: ${myType.ToString()}.");
    
    try
    {
    	var something = Activator.CreateInstance(myType);
    }
    catch (Exception exception)
    {
    	Console.WriteLine($"Failed to create an instance of {myType.ToString()}. Why? Error Message: {exception.Message}");
    }
