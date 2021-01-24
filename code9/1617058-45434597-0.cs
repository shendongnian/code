    if (ids.Select(x => x).All(x => Enum.IsDefined(typeof(IdEnum), x)))
    {
    	// All the companies in the list are present in the enum
    }
    else
    {
    
    }
