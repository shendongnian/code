    Public async Int Init()
    {
        Product p = new Product();
        Int productId = 10;
        Int UserId  = 101;
    
        Int count = 4;
    
        if(count > 0)
        {
            var result = p.XYZ();
        }
    
        if(count > 0)
        {
            var result = p.ABC();
        }
    
        if(count > 0)
        {
            var result = p.MNC();
        }
    
        if(count > 0)
        {
             await p.UpdateProduct(productId,UserId);
        }
    
        ------------etc (other stuff)------
    }
