    public string GetCommodities()
    {
        List<dynamic> categoryCommodityList = new List<dynamic>();
        foreach (var comcat in QuickQuoteRepo.CommodityCategories.All().OrderBy(o => o.Order))
        {
            var allCommodities = comcat.Commodities.OrderBy(o => o.Name).Select(com => com.Name).ToList();
            categoryCommodityList.Add(new { Catagory = comcat.Category, Items = allCommodities } );
        }
        return new JavaScriptSerializer().Serialize(categoryCommodityList);
    }
