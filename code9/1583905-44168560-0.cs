	interface IMyInterface
	{
		string SomeProperty {get;set;}
	}
	class MyClass : IMyInterface
	{
		public string SomeProperty {get;set;}
	}
	IQueryable<T> SomeMethod<T>() where T : IMyInterface, new()
	{
		var result = new List<T>() { 
            new T() { SomeProperty = "a"}, 
            new T() { SomeProperty = "b"} 
        };
		return result.AsQueryable();
	}
