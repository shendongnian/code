	void Main()
	{
		Test1();
		Test1();
		Test1();
		Test2();
		Test2();
		Test2();
	}
	
	void Test1()
	{
		System.Diagnostics.Stopwatch sw = new Stopwatch();
		MyObject1 mo = new MyObject1 { Name = "MyName" };
		sw.Start();
		long x = 0;
		for (int i = 0; i < 10000000; ++i)
		{
			
			x += CreateFileName(mo).Length;
		}
		Console.WriteLine(x); //Sanity Check, prevent clever compiler optimizations
		sw.ElapsedMilliseconds.Dump("Test1");
	}
	
	public string CreateFileName(MyObject1 obj)
	{
		return "sometext-" + obj.Name + ".txt";
	}
	
	void Test2()
	{
		System.Diagnostics.Stopwatch sw = new Stopwatch();
		MyObject2 mo = new MyObject2 { Name = "MyName" };
		sw.Start();
		long x = 0;
		for (int i = 0; i < 10000000; ++i)
		{
			x += mo.FileName.Length;
		}
		Console.WriteLine(x); //Sanity Check, prevent clever compiler optimizations
		sw.ElapsedMilliseconds.Dump("Test2");
	}
	
	
	
	public class MyObject1
	{
		public string Name;
	}
	
	public class MyObject2
	{
	    public string FileName { get; private set;}
		private string _name;
		public string Name
		{
			get 
			{
				return _name; 
			}
			set 
			{
				_name=value;
				FileName = "sometext-" + _name + ".txt";
			}
		}
	}
