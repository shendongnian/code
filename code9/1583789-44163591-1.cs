    void Main()
    {
    	var className = "UserQuery+Person";
    	var personType = Type.GetType(className);
    	var genericListType = typeof(List<>);
    	
    	var personListType = genericListType.MakeGenericType(personType);
    	
    	var personList = Activator.CreateInstance(personListType) as IList;
    
        // The following code is intended to demonstrate that this is a real
        // list you can add items to. 
        // In practice you will typically be using reflection from this point 
        // forwards, as you won't know at compile time what the types in 
        // the list actually are...
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
