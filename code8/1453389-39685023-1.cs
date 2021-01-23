    class Program
	{
		static void Main(string[] args)
		{
			var list = new List<Person>
			{
				new Person{ Name = "John" },
				new Person{ Name = "Amy" }
			};
			Func<Person, bool> pred = null;
			Roles role = Roles.RoleA;
			switch (role)
			{
				case Roles.RoleA:
					pred = p => p.Name.StartsWith("J");
					break;
				case Roles.RoleB:
					pred = p => p.Name.StartsWith("A") && p.Name.Length >= 3;
					break;
				default:
					break;
			}
			var result = list.Where(pred);
		}
	}
	class Person
	{
		public string Name { get; set; }
	}
	enum Roles
	{
		RoleA,
		RoleB
	}
