	public interface IA
	{
		bool PropertyDummy { get; set; }
	}
	public class A : IA
	{
		public bool ProprertyDummy { get; set; }
	}
	public class B {
		private IA _ia;
		public B(IA ia) { _ia = ia; }
		void method()
		{
			IA obj1 = _ia;
		}
	}
	public class C {
		private IA _ia;
		public C(IA ia) { _ia = ia; }
		void method()
		{
			IA obj1 = _ia;
		}
	}
	
	public class D {
		private IA _ia;
		public D(IA ia) { _ia = ia; }
		void method()
		{
			IA obj1 = _ia;
		}
	}
	
