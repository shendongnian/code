	void Main()
	{
		var json = @"{""Name"":""Jane Doe"",""Occupation"":""FBI Consultant"", ""Info"": {""Age"":28, ""Gender"":""Female""}}";
		Console.WriteLine("Match Name: " + json.JsonMatch("Name", "Jane Doe"));
		Console.WriteLine("Match Age: " + json.JsonMatch("Info.Age", "28"));
	}
	
	public static bool JsonMatch(this string json, string key, string value)
	{
		dynamic obj = JObject.Parse(json);
		var values = obj.PropertyValues();
		foreach (var element in values)
		{
			if (element.Path == key)
			{
				return element.Value == value;
			}
			if (element.Path == null)
			{
				foreach (var subelement in element)
				{
					if (subelement.Path == key)
					{
						return subelement.Value == value;
					}
				}
			}
		}
		return false;
	}
