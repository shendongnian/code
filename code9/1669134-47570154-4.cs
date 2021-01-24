	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Eyes Eyes { get; set; }
		
		// Empty ctor for various reasons
		public Person() { }	
		
		public Person(PersonDto dto)
		    : this()
		{
			Name = dto.Name;
			Age = dto.Age;
			Eyes = new Eyes
			{
				Color = dto.EyeColor
			};
		}
	}
	
	public class Eyes
	{
		public string Color{ get; set; }
	}
