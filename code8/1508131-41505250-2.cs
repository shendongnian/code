	public class Person
	{
		public Person(String name)
		{
			Name = name;
		}
		public String Name { get; set; }
		public int Age { get; set; }
	}
    try
    {
      p = new Person("kim");
	  p.Age = Convert.ToInt32("NOT AN INT");
    }
    catch (PersonException z) when(p.Name == "kim")
    {
      Console.WriteLine(z.Message);
    }
