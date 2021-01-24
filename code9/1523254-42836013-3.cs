	class Foo { }
	abstract class Bar
	{
		protected abstract Foo foo { get; }
		public Foo Foo => foo;
	}
	class Bar<TFoo> : Bar where TFoo : Foo
	{
		protected override Foo foo => this.Foo;
		public new TFoo Foo { get { ... } }
	}
