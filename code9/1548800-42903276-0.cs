    List<InvPurchaseDetail>  invPurchaselist = new List<InvPurchaseDetail>();
    foreach (var item in purchaseDetailTemp)
    {
        var newItem= new InvPurchaseDetail();
        newItem.ProductID = item.InvProductMasterID;
        newItem.ProductCode = item.ProductCode;
        newItem.ProductName = item.ProductName;
    	invPurchaselist.add(newItem)
    }
    context.InvPurchaseDetails.AddRange(invPurchaselist);
    context.SaveChanges();
