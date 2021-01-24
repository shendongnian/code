    void Main()
    {
    	var className = "UserQuery+Person";
    	var personType = Type.GetType(className);
    	var genericListType = typeof(List<>);
    	
    	var personListType = genericListType.MakeGenericType(personType);
    	
    	var personList = Activator.CreateInstance(personListType) as IList;
    
    	personList.Add(new Person { Name = "Alice" });
    	personList.Add(new Person { Name = "Bob" });
    
    	foreach (var person in personList.Cast<Person>())
    	{
    		Console.WriteLine(person.Name);
    	}
    }
    
    // Define other methods and classes here
    class Person
    {
    	public string Name { get; set;}
    }
