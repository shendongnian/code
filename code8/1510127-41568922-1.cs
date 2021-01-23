    /// <summary>
    /// Async Init method
    /// </summary>
    /// <returns>Awaitable task with int as return value</returns>
    public async Task<int> Init()
    {
        var p = new Product();
        var productId = 10;
        var UserId = 101;
        Task updateProduct = null;
    
        var count = 4;
    
        if (count > 0)
        {
            //this will start UpdateProduct method in different thread (asynchronously)
            updateProduct = p.UpdateProduct(productId, UserId);
        }
    
        //while UpdateProduct method is executing, other methods can be executed
        if (count > 0)
        {
            var result = p.XYZ();
        }
    
        if (count > 0)
        {
            var result = p.ABC();
        }
    
        if (count > 0)
        {
            var result = p.MNC();
        }
    
        //------------etc (other stuff)------
    
        //before leaving method, ensure UpdateProduct has finished its job
        if (updateProduct != null)
            await updateProduct;
    
        return 1;
    }
