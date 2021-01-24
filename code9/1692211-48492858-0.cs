    try
    {
        var store = storeFactory.Create(id); // Can Throw ArgumentException
        try
        {
           var order = await store.GetOrderAsync(orderId); //Can Throw ArgumentException
    
           return Ok(order);
        }
        catch ( ArgumentException ex )
        {
           return NotFound("Order Id Was Not Found");
        }
    }
    catch (ArgumentException ex)
    {
        //TODO: How To Tell Which Methods Throw The Exception (Create Or GetOrderAsync)
        return NotFound("Store Id Was Not Found");
    }
