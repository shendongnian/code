    enum Foo { Bar, Baz,bread=0, jam=0};
 
	public static void Main()
	{
		Console.WriteLine((int)Foo.Bar);  // 0
		Console.WriteLine((int)Foo.Baz);  // 1
		Console.WriteLine((int)Foo.bread); // 0
		Console.WriteLine((int)Foo.jam);  // 0
	}
