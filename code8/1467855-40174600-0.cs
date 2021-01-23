    var ord = data1.OrderByDescending(o => o.Sales)
                   .Select(o => o.Product)
                   .Distinct()
                   .ToList(); //Get products by their sales
    var topProducts = ord.Take(ord.Count() < 5 ? ord.Count() : 5)
                   .ToList(); //Take top 5 products
    var salesForTopProducts = data1.OrderByDescending(o => o.Sales)
                                   .Where(o => topProducts.Contains(o.Product))
                                   .ToList();//Get all sales for top 5 products
    var topSales = salesForTopProducts.Take(salesForTopProducts.Count() < 20 ? salesForTopProducts.Count() : 20)
                                      .ToList();//Get top 20 sales for top 5 products
