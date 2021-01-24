	public static List<string> GetListOfValues(IEnumerable<Person> listOfPersons, string propertyName)
	{
		var ret = new List<string>();
		PropertyInfo prop = typeof(Person).GetProperty(propertyName);
		if (prop != null)
			ret = listOfPersons.Select(p => prop.GetValue(p).ToString()).Distinct().OrderBy(x => x).ToList();
		return ret;
	}
