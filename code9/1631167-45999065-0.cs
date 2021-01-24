    public async Task<IHttpActionResult> Get() 
    {
        try 
        {
             var result = await GetAllCustomersAsync();
             return Ok(result);
        }
        catch(Exception ex) 
        {
            return InternalServerError(ex);
        }
    }
    
    private async Task<Customers> GetAllCustomersAsync()
    {
        ....
        return customers;
    }
