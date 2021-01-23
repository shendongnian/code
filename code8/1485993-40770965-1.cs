	using (TransactionScope transaction = new TransactionScope())
	{
		try
		{
			//Do whatever
			
			transaction.Complete();
		}
		catch (Exception)
		{
		    throw;
		}
	}
