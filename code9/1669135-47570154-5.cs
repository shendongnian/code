	public class Person
	{
		public string Name { get; set; }
		public int Age { get; set; }
		[JsonIgnore]
		public Eyes Eyes { get; set; }
		
		public string EyeColor 
		{
			get { return Eyes.Color; }
			set { Eyes.Color =  value; }
		}
		
		public Person()
		{
			this.Eyes = new Eyes();
		}
	}
