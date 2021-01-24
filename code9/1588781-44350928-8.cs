	void Main()
	{
		var foo = new Foo()
		{
			Id = 1,
			Name = "One"
		};	
		
		string json = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
		var bar = Newtonsoft.Json.JsonConvert.DeserializeObject<Bar>(json); // nulls/defaults
		
        JsonSerializerSettings jss = MyCustomJsonSerializerSettings.Jss;
		string json2 = Newtonsoft.Json.JsonConvert.SerializeObject(foo, jss);
		var bar2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Bar>(json2); // as expected!
	}
