    private void On_ProductReceived(object sender, ProductReceivedArgs e)
    {
        // Variable to hold potential list of products to save
        List<Products> productsToSave;
        // Lock buffer
        lock(ProductBuffer)
        {
            ProductBuffer.Enqueue(e.Product);
            
            // If it is under size, return immediately
            if (ProductBuffer.Count < handlerConfig.ProductBufferSize)
                return;
            // Otherwise save products, clear buffer, release lock.
            productsToSave = ProductBuffer.ToList();
            
            ProductBuffer.Clear();
        }
        
        // Save Produts, 
        SaveProducts(products);
    }
