	public void BulkInsertObj(List<TEntity> objList)
    {
		using (var context = new dbContext()) 
		{ 
			using (var dbContextTransaction = context.Database.BeginTransaction()) 
			{  
			    try 
				{ 
					foreach(var obj1 in objList)
					{
						dbContext.MyTable.Add(obj1);
						//obj1 should be on the context now 
						var previousEntity = dbContext.MyTable.Where(.....) //However you determine this
						previousEntity.field = something
						
						var nextEntity = dbContext.MyTable.Where(.....) //However you determine this
						nextEntity.field = somethingElse
					}
					context.SaveChanges(); 
					dbContextTransaction.Commit(); 
				} 
				catch (Exception) 
				{ 
					dbContextTransaction.Rollback(); 
				} 
			} 
		} 
    }
