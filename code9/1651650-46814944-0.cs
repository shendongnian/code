    var result = (from c in db.Products
                  select new ProductDetails
                  {
                     ProductName = c.ProductName,
                     Price = c.Price,
                     Categories = null 
                  })
      .ToList()  // Execute the query before updating the property
      .Select(pd => {
        pd.Categories = CategoryDetails();
        return pd;
      })
      .ToList();
