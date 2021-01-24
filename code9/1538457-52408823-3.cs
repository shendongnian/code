    using (var ctx = new tpc_soContext())
    {
    	ctx.BaseEntities.Add(new FirstDerivedEntity()
    	{
    		BaseEntityId = Guid.NewGuid(),
    		Comments = new List<Comment>() { new Comment() { Text = "First Derived Comment" } }
    	});
    
    	ctx.BaseEntities.Add(new SecondDerivedEntity()
    	{
    		BaseEntityId = Guid.NewGuid(),
    		Comments = new List<Comment>() { new Comment() { Text = "Second-Derived Comment" } }
    	});
    
    	ctx.SaveChanges();
    }
