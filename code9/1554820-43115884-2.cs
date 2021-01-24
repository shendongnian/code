    public IPagedList<SGProduct> GetFilteredProducts(string catID, string[] houseID, int page = 1)
    {
        var query = MongoContext.Products.AsQueryable<SGProduct>();
        if(houseID == null)
            query = query.Where(x =>houseID.Contains(x.HouseID.ToString()) && x.ProductCategoryID.ToString() == catID);
        return query.ToList().ToPagedList(page, 6);
    }
