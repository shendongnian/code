    var str = MYExecutionStrategy(3, TimeSpan.FromSeconds(1));
    
    	str.Execute(() =>
    	{
    		using (DemoEntities objContext = GetWDemoEntities ())
    		{
    			using (TransactionScope obj = new TransactionScope())
    			{
    				Demo1 objDemo1 = new Demo1();
    				objDemo1.Title = "ABC";
    				
    				objContext.Demo1.Add(objDemo1);		
    				objContext.SaveChanges(); // First SaveChanges() method called.
    				
    				Demo2 objDemo2 = new Demo2();
    				objDemo2.Title = "ABC";
    				
    				objContext.Demo2.Add(objDemo2);		
    				objContext.SaveChanges();// Second SaveChanges() method called.
    				
    				obj.Complete();
    			}
    		}
    	}
