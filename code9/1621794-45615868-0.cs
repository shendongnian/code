    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Dog	fuffy = new Dog("Fuffy", "Amarant");
    			Console.WriteLine(fuffy.Name);
    			Console.WriteLine(fuffy.Breed);
		}
	}
	class Dog
	{
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private string breed;
		public string Breed
		{
			get { return breed; }
			set { breed = value; }
		}
		public Dog(string pName, string pBreed)
		{
			Breed = pBreed;
			Name = pName;
		}
	}
