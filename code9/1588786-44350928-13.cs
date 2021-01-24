	class Foo
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
	
	class Bar
	{
		public int BarId { get; set; }
		public string BarName { get; set; }
	}
	void Main()
	{
		var foo = new Foo()
		{
			Id = 1,
			Name = "One"
		};	
		string json = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
		
		
		var bar = Newtonsoft.Json.JsonConvert.DeserializeObject<Bar>(json);
	}
