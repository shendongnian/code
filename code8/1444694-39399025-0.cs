    int batchSize = 10;
    
    for (int i = 0; i < = someList.Count / batchSize; i++)
    {
    	var batch = someList.Skip(batchSize * i).Take(batchSize);
    	
    	using (var sqllite = new nyEntities())
    	{
    		foreach(var item in batch)
    		{
    			var newItem = new Item() {...};
    			
    			sqllite.tableName.Add(newItem);
    		}
    
    		sqllite.SaveChanges();
    	}
    }
