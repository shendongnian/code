	class Foo { }
	class Bar
	{
		public virtual Foo Foo { get; }
	}
	class Bar<TFoo> : Bar where TFoo : Foo
	{
		public override TFoo Foo { get; }
	}
