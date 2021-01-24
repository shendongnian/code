	public class Person
	{
		public string Name { get; }
		public int Age { get; }
	
		public Person(string name, int age)
		{
			Name = name;
			Age = age;
		}
	}
	var people = new Person[]
	{
		new Person("John", 25), new Person("Peter", 25), new Person("Sean", 25),
		new Person("John", 32), new Person("Peter", 32),
	};
	
	var query = people.AsQueryable();
	
	var namePropertyExpression = "Name".AsPropertyExpression<Person, string>();
	var agePropertyExpression = "Age".AsPropertyExpression<Person, int>();
	
	// When you know the result type
	var names1 = query.GetDistinctValuesForProperty(x => x.Name);
	var ages1 = query.GetDistinctValuesForProperty(x => x.Age);
	
	// When you know the result type, but you may want to reuse the property expression
	var names2 = query.GetDistinctValuesForProperty(namePropertyExpression);
	var ages2 = query.GetDistinctValuesForProperty(agePropertyExpression);
	
	// When you just know the property name
	var names3 = query.GetDistinctValuesForProperty("Name");
	var ages3 = query.GetDistinctValuesForProperty("Age");
