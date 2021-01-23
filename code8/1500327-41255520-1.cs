	using (TransactionScope tx = new TransactionScope())
	{
	  using (ISession session1 = ...)
	  using (ITransaction tx1 = session.BeginTransaction())
	  {
		...do work with session
		tx1.Commit();
	  }
	  using (ISession session2 = ...)
	  using (ITransaction tx2 = session.BeginTransaction())
	  {
		...do work with session
		tx2.Commit();
	  }
	  tx.Complete();
	}
