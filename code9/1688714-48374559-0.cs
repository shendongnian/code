    using (var context = new YourContext())
    {
        var result = context.SaleFactors
                .Where(x => x.SaleProducts.SaleDate >= 2016  &&x.SaleProducts.SaleDate <= 2018 )
                .Select(x => new
      {
         FactorId = x.FactorId ,
         CustomerId = x.Customers.CustomerId  ,
         CustomerName = x.Customers.CustomerName ,
         SaleDate = x.SaleProducts.SaleDate .
    
      }).Distinct().ToList();
