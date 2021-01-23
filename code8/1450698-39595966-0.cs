    var processedProductCodes = new HashSet<string>();
    
    var po = new ParallelOptions()
            {
                MaxDegreeOfParallelism = 4
            };
    
    Parallel.ForEach(validProducts, po,
                (product) =>
    {
                //You can safely lock on processedProductCodes
                lock (processedProductCodes)
                {
                    if(!processedProductCodes.Add(product.ProductCode))
                    {
                        //Add returns false if the code is already in the collection.
                        return;
                    }
                }
    
        // Check if Product Exists in Db
    
        // if product is not in Db Add to Db
    
        // if product is in Db Update product in Db
    
    }
