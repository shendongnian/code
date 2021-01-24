	struct Foo {
		public int A {get;set;}
		public void SetA(int a) {
			A = a;
		}
	}
 
	class Bar {
		Foo f;
		public Foo F {
			get{return f;}
			set {f = value;}
		}
		public void SetFooA(int x) {
			f.SetA(x);
		}
	}
 
	public static void Main() {
		Bar b = new Bar();
		b.F.SetA(123);  // b.F makes a copy, so changing A fails
		Console.WriteLine("{0}", b.F.A);
		b.SetFooA(456); // Inside Bar, f.SetA is called directly, so the change works fine
		Console.WriteLine("{0}", b.F.A);
		b.F = new Foo { A = 112233 }; // This also works, because the whole F is assigned
		Console.WriteLine("{0}", b.F.A);
	}
