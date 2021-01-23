	// External Assemblies A and B define the following types:
	// Assembly A
	public class X
	{
		public string Name { get; set; }
		public static void SomeFunction(X item)
		{
			Console.WriteLine($"X.{item.Name}");
		}
	}
	// Assembly B
	public class Y
	{
		public string Name { get; set; }
		public static void SomeFunction(Y item)
		{
			Console.WriteLine($"Y.{item.Name}");
		}
	}
	// We would create an implicit intermediary in intermediate assembly C
	// Assembly C
	public class Z
	{
		public string Name { get; set; }
		public static implicit operator Z(X input) => new Z { Name = input.Name };
		public static implicit operator X(Z input) => new X { Name = input.Name };
		public static implicit operator Z(Y input) => new Z { Name = input.Name };
		public static implicit operator Y(Z input) => new Y { Name = input.Name };
	}
	public void PushToX(Z thing) => X.SomeFunction(thing);
	public void PushToY(Z thing) => Y.SomeFunction(thing);
	public void DoThing(Z thing)
	{
		Console.WriteLine(thing.Name);
	}
	public void Main()
	{
		var a = new X { Name = "A" };
		var b = new Y { Name = "B" };
		DoThing(a);
		DoThing(b);
		PushToX(a);
		PushToY(a);
		PushToX(b);
		PushToY(b);
		//A
		//B
		//X.A
		//Y.A
		//X.B
		//Y.B
	}
