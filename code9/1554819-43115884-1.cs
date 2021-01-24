    public IPagedList<SGProduct> GetFilteredProducts(string catID, string[] houseID, int page = 1)
    {
        if(houseID == null) houseID = new string[] {};
        return MongoContext.Products.AsQueryable<SGProduct>().AsEnumerable().Where(x =>houseID.Contains(x.HouseID.ToString()) && x.ProductCategoryID.ToString() == catID).ToList().ToPagedList(page, 6);
    }
