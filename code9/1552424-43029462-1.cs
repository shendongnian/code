	typeof(SomeClass).GetCustomAttributes(false);//without this line, GetHashCode behaves as expected
	SomeAttribute tt = new SomeAttribute();
	Console.WriteLine(tt.GetHashCode());//Prints 1234567
	Console.WriteLine(tt.GetHashCode());//Prints 0
	Console.WriteLine(tt.GetHashCode());//Prints 0
	foreach (var field in new SomeAttribute().GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
	{
		Console.WriteLine(field.Name);
	}
