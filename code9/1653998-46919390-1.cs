	public static void Main()
	{
		var c = new MyClass();
		c.Child = new MyClass.SubClass();
	    byte[] bytes;
        using (MemoryStream stream = new MemoryStream())
        {
            new BinaryFormatter().Serialize(stream, c);
            bytes = stream.ToArray();
        }	
	    Console.WriteLine("Success");	
     }
