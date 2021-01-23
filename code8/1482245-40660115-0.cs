    public static object GetPersonField(Person person, Type fieldType)
    {
    	return typeof (Person)
    			.GetProperties()
    			.Single(p => p.PropertyType == fieldType)
    			.GetValue(person);
    }
