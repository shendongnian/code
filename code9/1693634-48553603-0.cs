	public static void Main()
	{
		
		string input = @"{ ""message"": ""I've been shot!"", ""phoneNumber"": ""12345?"", ""position"": ""???"", ""anon"": ""???"", ""job"": ""ambulance"" }";
		var objectTemplate = new
		{
			message = "", 
			phoneNumber = "", 
			position = "", 
			anon = "", 
			job = ""
		};
		
		var deserialized = JsonConvert.DeserializeAnonymousType(input, objectTemplate);
		
		Console.WriteLine(deserialized.message);
		Console.WriteLine(deserialized.phoneNumber);
		Console.WriteLine(deserialized.position);
		
	}
