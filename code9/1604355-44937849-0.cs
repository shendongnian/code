	void Main()
	{
		var foos = Enumerable.Repeat(new Foo(), 2).ToArray();
		foos[0].Name = "Jack";
		foos[1].Name = "Jill";
		Console.WriteLine(foos[0].Name);	
	}
	
	public class Foo
	{
		public string Name;
	}
