	class A
	{
		private static  IDbTransaction Transaction;
		private static  IDbConnection conn;
	
		static void Main()
		{
			B test = new B();
			//[some instruction]
			Transaction = conn.BeginTransaction();
			test.Save(Transaction);
		}
	}
	
	class B
	{
		public B()
		{		
		}
	
		public void Save(IDbTransaction transaction)
		{
			//[some instruction that use transaction]
			transaction
	    }
	}
