	class Authorisation
	{
		public int AuthorisationId; // yetkiliid
		public int AccessId; // unvanid
		public string AuthoriserName;
	}
	class Access
	{
		public int AccessId; // unvanid
		public string AccessName;
	}
	class Customer
	{
		public int CustomerId; // musterid
		public string CustomerName;
	}
	class Event
	{
		public int CustomerId;
		public int AuthorisationId;
	}
	
	void Main()
	{
		var Customers = new[] {
			new Customer() { CustomerId = 1, CustomerName = "Anne" },
			new Customer() { CustomerId = 2, CustomerName = "Barbara" },
		};
		var Accesses = new[] {
			new Access() { AccessId = 1, AccessName = "Read" },
			new Access() { AccessId = 2, AccessName = "Write" },
		};
		var Authorisations = new[] {
			new Authorisation() { AuthorisationId = 1, AuthoriserName = "The boss", AccessId = 1 }, // The boss can give read rights
			new Authorisation() { AuthorisationId = 2, AuthoriserName = "The boss", AccessId = 2 }, // The boss can give write rights
			new Authorisation() { AuthorisationId = 3, AuthoriserName = "A rookie", AccessId = 1 }, // A new employee can only give read rights
		};
		var Events = new[] {
			new Event() { CustomerId = 1, AuthorisationId = 3 }, // A rookie let Anne read
			new Event() { CustomerId = 1, AuthorisationId = 2 }, // While the boss let Anne write and scolded rookie
			new Event() { CustomerId = 2, AuthorisationId = 1 }, // The boss thinks Barbara can't be trusted with write
		};
	}
