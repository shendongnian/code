    public static List<T> GetListOfProperty<T>(IEnumerable<Person> 
        listOfPersons, string property)
    {
        Type t = typeof(Person);         
        PropertyInfo prop = t.GetProperty(property);
        return listOfPersons
            .Select(person => (T)prop.GetValue(person))
            .Distinct()
            .OrderBy(x => x)
            .ToList();
    }
