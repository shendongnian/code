    public static List<string> GetListOfProperty(IEnumerable<Person> 
        listOfPersons, string property)
    {
        Type t = typeof(Person);         
        PropertyInfo prop = t.GetProperty(property);
        return listOfPersons
            .Select(person => (string)prop.GetValue(person))
            .Distinct()
            .OrderBy(x => x)
            .ToList();
