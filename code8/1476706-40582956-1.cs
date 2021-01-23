	dynamic val = dynamicObject["propertyName"];
	if (object.ReferenceEquals(val, null))
	{
		Console.WriteLine("property does not exist.");
	}
	else if (val == null)
	{
		Console.WriteLine("property exists with a value of null.");
	}
	else
	{
		Console.WriteLine("property exists with with a value of \"" + val.ToString() + "\".");
	}
