	using (TransactionScope scope = new TransactionScope())
	{
		using (MyDBContext db = new MyDBContext())
		{
		   //...
		   db.SaveChanges()
		}
		   scope.Complete();
		}
		using (MyDBContext db = new MyDBContext())
		{
		   //...
		   db.SaveChanges()
		}
		   scope.Complete();
		}
	/* end of adding transaction scope*/
	}
