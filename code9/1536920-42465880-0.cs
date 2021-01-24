    // Server method:
    [HttpGet]
    [Route("GetAllProductItems")]
    public IQueryable<ProductItem> GetAllProductItems()
    {
        return Query();
    }
    
    // Client call
    var result = await MobileService.InvokeApiAsync<IQueryable<ProductItem>>("ProductItem/GetAllProductItems", HttpMethod.Get, null);
