    var token = ctx.BulkStores.FirstOrDefault(x => x.StoreName == store && x.Type == 1).Token;
    
    var RootObject = new RootObject() {
        Token = token,
        file = new File() {
            nameLocator = "testimport1",
            itemsDeatails = new ItemsDeatails() {
                ItemsFromFile = new List<ItemsFromFile>()
            }
        }
    };
    var singleItems = ctx.BulkScannedItems.Where(x => x.UserSellerScanRequestId == id).ToList();
    foreach (var item in singleItems) {
        RootObject.file.itemsDeatails.ItemsFromFile.Add(new ItemsFromFile { ASIN = item.ASIN, Title = item.EbayTitle });
    }
