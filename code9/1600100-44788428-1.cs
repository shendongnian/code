    public double TotalProductDiscountHistory(DateTime datePurchased, double cost) {...}
    class CategoryTotals
    {
         public int Category {get; set;}
         public double Cost {get; set;}
         public double TotalDiscounts {get; set;}
    }
    var query = from p in db.Products
                where P.clientId == clientId
                group p by p.Category;
     var totals = new List<CategoryTotals>();
    foreach(var grp in query)
    {
         var ct = new CategoryTotals
                {
                    Category =grp.Category,
                    Cost = grp.Sum(u => u.Cost),
                    TotalDiscounts = grp.Sum(u=> 
                            TotalProductDiscountHistory(u.DatePurchased, u.Cost))
                };
         totals.add(ct);
    }
