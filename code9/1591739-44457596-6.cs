    [Route("inventory")]
    public IHttpActionResult PostInventories(long TenantId, 
       [FromBody] List<Inventory> inventories) // parameter will be deserialized automatically
    {
        foreach (var item in inventories)
        {
            //...
        }
        // catching and rethrowing exception is redundant as well
        return Ok();
    }
