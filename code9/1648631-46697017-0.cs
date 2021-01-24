  	public static IDictionary<int, Employees> EmployeesToDictionary(Employees employees)
	{
		var dictionary = new Dictionary<int, Employees>();
		EmployeesToDictionary(employees, dictionary);
		return dictionary;
	}
	private static void EmployeesToDictionary(Employees employees, IDictionary<int, Employees> dictionary)
	{
		if (employees == null) return;
		dictionary.Add(employees.Id, employees);
		foreach (var sub in employees.employees)
		{
			EmployeesToDictionary(sub);
		}
	}
