	public class MyClass
	{
	   public Interface2 MyDataAccess { get; set; }
	   public void TestInheritance()
	   {
			foreach (var property in typeof(MyClass).GetProperties())
			{
				var type = property.PropertyType;
				var inheritsproperty = typeof(Interface1).IsAssignableFrom(type);
				if (inheritsproperty)
				{
					//does hit
				}
			}
	   }
	}
