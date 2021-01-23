    	public class Example
	{
		private const string S = "123";
		readonly int a;
		public int A
		{
			get
			{
				Contract.Ensures(Contract.Result<int>() < 3);
				Contract.Ensures(Contract.Result<int>() >= 0);
				return a;
			}
		}
		[ContractInvariantMethod]
		private void ObjectInvariant()
		{
			Contract.Invariant(a >= 0);
			Contract.Invariant(a < 3);
		}
		public Example(int a)
		{
			Contract.Requires(a >= 0);
			Contract.Requires(a < 3);
			this.a = a;
		}
		public static char Test(Example x)
		{
			Contract.Requires(x != null);
			return S[x.A];
		}
	}
