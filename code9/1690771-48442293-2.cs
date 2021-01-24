    interface MyInterface
	{
		A A { get; }
	}
	class A : MyInterface
	{
		public B A { get; private set; } // this will NOT implement the interface, although B derives from A
	}
	class B : A { }
