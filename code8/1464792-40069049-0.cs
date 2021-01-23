    public class Test : ITest<IClassA>
	{
		public IClassA A
		{
			get; private set;
		}
	
		public Test(IClassA a)
		{
			this.A = a;
		}
	}
