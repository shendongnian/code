	class A
	{
		private static TransactionInfo info = new TransactionInfo();		
	
		static void Main()
		{
			B test = new B(info);
			//[some instruction]
			info.Transaction = info.conn.BeginTransaction();
			test.Save();
		}
	}
	
	class B
	{
		private TransactionInfo _info;
	
		public B(TransactionInfo info)
		{
			_info = info;
		}
	
		public void Save()
		{
			//[some instruction that use transaction]
			_info.Transaction;
		}
	}
