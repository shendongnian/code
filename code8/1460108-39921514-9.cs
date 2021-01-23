	using(var unitOfWork = new UnitOfWork())
	using(var transaction = new unitOfWork.BeginTransaction())
	{
		 try
		 {
			 repository.Users.Add(new User(... User One ...))
			 repository.Save();
			 repository.Addresses(new Address(... Address For User One ...))
			 repository.Save();
			 repository.Users.Add(new User(... User Two...))
			 repository.Save();
			 repository.Addresses(new Address(... Address For User Two...))
			 repository.Save();
			 transaction.Commit();
		 } 
		 catch(Exception)
		 {
			  transaction.Rollback();
		 }
	}
