       var itemDetails = new ItemsDeatails();
        
        itemDetails.ItemsFromFile = new ItemsFromFile();
        var singleItems = ctx.BulkScannedItems.Where(x => x.UserSellerScanRequestId == id).ToList();
        
        foreach (var item in singleItems)
                {
                    itemDetails.ItemsFromFile.products.Add(new Product { ASIN = item.ASIN, Title = item.EbayTitle });
                }
        
        var fl = new File(){
            nameLocator = "testimport1",
            itemsDeatails = itemDetails
        }
        
        var token = ctx.BulkStores.FirstOrDefault(x => x.StoreName == store && x.Type == 1).Token;
    
        var root = new RootObject()
        {
            Token = token,
            file = fl
        }
        
        var json = new JavaScriptSerializer().Serialize(root);
