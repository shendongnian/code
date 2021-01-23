    public EntityDto Get(int id)
    {
    	return WebHelpers.GetHelper<Entity, EntityDto>(() =>
    	{
    		using (var db = new DbConext())
    		{			
    			return db.Entities.Find(id);			
    		}
    	});
    }
