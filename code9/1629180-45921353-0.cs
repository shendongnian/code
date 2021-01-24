	using (var context1 = new Context1())
	{
		using (var transaction = context1.Database.BeginTransaction())
		{
			try
			{
				context1.Add(someCollection1);
				context1.SaveChanges();
				// if we don't have errors - next step 
				using(var context2 = new Context2())
				{
                   // second step
				   context2.Add(someCollection2);
				   context2.SaveChanges();
				}	
                // if all success - commit first step (second step was success completed)
				transaction.Commit();
			}
			catch (Exception)
			{
                // if we have error - rollback first step (second step not be able accepted)
				transaction.Rollback();
			}
		}
	}
