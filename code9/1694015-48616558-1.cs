    [HttpGet]
    public async Task<IStore> GetStore(int id)
    {
    	IStore result = await ShopExpressions.Store(GenericExpressions.ClientAccess(this.Worker.GetRepo<Store>().DbSet))
    		.SingleAsync(str => str.Id.Equals(id));
    
    	this.Worker.ValidateClientAccess(result);
    
    	return result;
    }
    
    [HttpGet]
    public async Task<IStore> GetStoreLite(int id)
    {
    	IStore result = await ShopExpressions.StoreLite(GenericExpressions.ClientAccess(this.Worker.GetRepo<Store>().DbSet))
    		.SingleAsync(str => str.Id.Equals(id));
    
    	this.Worker.ValidateClientAccess(result);
    
    	return result;
    }
    
    [HttpGet]
    public async Task<IPage> GetPage(int id)
    {
    	IPage result = await ShopExpressions.Page(this.Worker.GetRepo<Page>().DbSet)
    		.SingleAsync(page => page.Id.Equals(id));
    
    	return result;
    }
