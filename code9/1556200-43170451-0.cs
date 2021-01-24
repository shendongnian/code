    public ActionResult ViewMyBids()
    {
        var db = new AuctionsDataContext();
        var pKey = User.Identity.GetUserId();
        // I want to pass the primary key in to the auction model and get the results to a list 
        var result = db.Auctions
            .Where(p => p.SellerUserID == pKey)
            .ToList();
        // The result is a List<Auction> so the below code won't work unless you retrieve only one item
        // ViewBag.mes = result.SellerUserID;
        return ViewMyBids();
    }
