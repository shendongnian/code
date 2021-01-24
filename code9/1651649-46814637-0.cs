      var result = (from c in db.Products
                      select new ProductDetails
                      {
                         ProductName = c.ProductName,
                         Price = c.Price,
                         Categories = null 
                      }).ToList();
     foreach (var c in result)
         {
           c.Categories= CategoryDetails();
         }
         return View(result);
