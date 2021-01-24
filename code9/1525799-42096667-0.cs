    private List<Type> alreadyVisitedTypes = new List<Type>(); // to avoid infinite recursion
    public static void PrintAllTypes(Type currentType, string prefix)
	{
	    if (alreadyVisitedTypes.Contains(currentType)) return;
		alreadyVisitedTypes.Add(currentType);
		foreach (PropertyInfo pi in currentType.GetProperties())
		{
		    Console.WriteLine($"{prefix} {pi.PropertyType.Name} {pi.Name}");
			if (!pi.PropertyType.IsPrimitive) PrintAllTypes(pi.PropertyType, prefix + "  ");
	    }
	}
