    public async Task<IStore> GetStoreLite(int id)
    {
    	IStore result = await ShopExpressions.StoreLite(GenericExpressions.ClientAccess(this.Worker.GetRepo<Store>().DbSet))
    		.SingleAsync(str => str.Id.Equals(id));
    
    	this.Worker.ValidateClientAccess(result);
    
    	return result;
    }
