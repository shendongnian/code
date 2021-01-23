	void Main()
	{
		var obj = new TestObject();
		foreach (var prop in obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
		{
			Console.WriteLine("{0} = '{1}'", prop.Name, prop.GetValue(obj));
		}
	}
	
	class TestObject
	{
		private readonly string _firstName;
		private readonly string _lastName;
	
		public TestObject()
		{
			_firstName = "John";
			_lastName = "Hancock";
		}
	}
