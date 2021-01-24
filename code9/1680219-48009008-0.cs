	public class Person
	{
		public int Id {get; set;}
		public string Name {get; set;}
		public int Age {get; set;}
	}
	//sync request
	public class PersonRequest : Person, IRequest<Person>
	{ }
	//async request
	public class PersonRequestAsync : Person, IRequest<Person>
	{ }
