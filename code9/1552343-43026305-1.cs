	void Main()
	{
		var impl = new Impl{ TheProperty = 42 };
		int i = impl.TheProperty;
		Console.WriteLine(i);
		
		var b = new ClassB<Impl>{ TheProperty = impl };
		i = (int)b.ThePropertyProperty;
		Console.WriteLine(i);
	
        Console.WriteLine(b.TypeOfTB.Name);
	}
