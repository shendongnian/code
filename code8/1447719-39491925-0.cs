	class A
	{
		public Func<string, B> this [string i] => j => new B();
	}
	class B
	{
		public A this[string i] => new A();
	}
	class Program
	{
		static void Main(string[] args)
		{
			A a = new A();
			a[""]("")[""][""]("");
		}
	}
	
