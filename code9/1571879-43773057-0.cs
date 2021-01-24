	// Define the search string
	List<string> searchInput = new List<string> { "Paul", "Henry Gates", "Gates Henry" };
	
	// Define the data
	List<Person> persons = new List<Person>();
	persons.Add(new Person() { FirstName = "William", MiddleName = "Henry", LastName = "Gates" });
	persons.Add(new Person() { FirstName = "Steven", MiddleName = "Paul", LastName = "Jobs" });
	persons.Add(new Person() { FirstName = "Mark", MiddleName = "Elliot", LastName = "Zuckerberg" });
	
	// It may problem if you want to specific the field in sequence
	persons.Add(new Person() { FirstName = "Henry", MiddleName = "Elliot", LastName = "Gates" });
	// Another problem if a field contains all values
	persons.Add(new Person() { FirstName = "Henry Gates", MiddleName = "Elliot", LastName = "Gates" });
	
	// find the person
	foreach (string input in searchInput)
	{
		List<string> inputList = input.Split(' ').Select(s => s.ToUpperInvariant()).ToList();
		var qry = persons.Where(p => inputList.Contains(p.FirstName.ToUpperInvariant()) ||
										inputList.Contains(p.MiddleName.ToUpperInvariant()) ||
										inputList.Contains(p.LastName.ToUpperInvariant()));
		var results = qry.ToList();
		Console.WriteLine(string.Format("Search: {0} Found: {1}", input, results.Count));
		foreach(var p in results)
		{
			Console.WriteLine(p.ToString());
		}
		Console.WriteLine();
	}
