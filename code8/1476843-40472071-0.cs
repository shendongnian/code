    public static string ProductNameList(Promotion promotion, string category) {
        var products = promotion.Offers
            .Where(x => x.CategoryName == category)
        	.SelectMany(x => x.Product)
        	.Select(x => x.ProductName);
        return String.Join(", ", products);
    }}
