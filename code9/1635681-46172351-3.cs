	public class BoolContainer
	{
		public bool SomeValue { get; set; }
	}
	public class Foo
	{
		private BoolContainer _boolContainer;
		
		public Foo(BoolContainer boolContainer)
		{
			_boolContainer = boolContainer;
		}
		
		public void Foo2()
		{
			_boolContainer.SomeValue = true;
		}
	}
