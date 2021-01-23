    JObject jo = (JObject)dynamicObject;
	JToken token = jo["propertyName"];
	if (token == null)
	{
		Console.WriteLine("property does not exist.");
	}
	else if (token.Type == JTokenType.Null)
	{
		Console.WriteLine("property exists with a value of null.");
	}
	else
	{
		Console.WriteLine("property exists with with a value of \"" + token.ToString() + "\".");
	}
