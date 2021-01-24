	public static void Main()
	{
		var json = @"{""operation"": {
			""type"": ""ADD"",
			""args"": [
				{
					""type"": ""ADD"",
					""args"": [
						{
							""columnName"": ""SomeColumnB"",
							""row"": 12
						},
						{
							""columnName"": ""SomeColumnC"",
							""row"": 18
						}
					]
				}
			]
  		}}";
		dynamic data = JsonConvert.DeserializeObject(json);
		
		Console.WriteLine(data.operation.type.ToString());
		Console.WriteLine(data.operation.args[0].args[0].columnName.ToString());
		Console.WriteLine((int)data.operation.args[0].args[0].row);
	}
