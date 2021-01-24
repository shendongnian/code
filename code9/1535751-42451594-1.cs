	public class A : IFoo
	{
		public void Foo() { Console.Write("A"); }
		public IList<B> Bs { get; set; } = new List<B>() { new B(), new B(), };
		public IList<C> Cs { get; set; } = new List<C>() { new C(), new C(), };
	}
	
	public class B : IFoo
	{
		public void Foo() { Console.Write("B"); }
		public IList<D> Ds { get; set; } = new List<D>() { new D(), new D(), };
	}
	
	public class C : IFoo
	{
		public void Foo() { Console.Write("C"); }
	}
	
	public class D : IFoo
	{
		public void Foo() { Console.Write("D"); }
	}
	
	public interface IFoo
	{
		void Foo();
	}
