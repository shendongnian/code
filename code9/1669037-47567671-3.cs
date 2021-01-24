	void Main()
	{
		A a = new A();
		B b = new B();
		if (a == b)
		{
			// ...
		}
	}
	class A
	{
		public static bool operator == (B b, A a)
		{
			Console.WriteLine("A");
			return false;
		}
		
		public static bool operator != (B b, A a)
		{
			Console.WriteLine("A");
			return false;
		}
			
		public override bool Equals(object o)
		{
			return false;
		}
		
		public override int GetHashCode()
		{
			return 0;
		}
	}
	
	class B
	{	
		public static bool operator == (A a, B b)
		{
			Console.WriteLine("B");
			return false;
		}
		
		public static bool operator != (A a, B b)
		{
			Console.WriteLine("B");
			return false;
		}
		
		public override bool Equals(object o)
		{
			return false;
		}
		
		public override int GetHashCode()
		{
			return 0;
		}
	}
