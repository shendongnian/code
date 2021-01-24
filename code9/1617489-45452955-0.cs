      IEnumerable<Product> productList = new List<Product>  {
          new Product  { ProductID = 1, ProductName = "Chai", Category = "Beverages",
            UnitPrice = 18.0000M, UnitsInStock = 39 },
          new Product{ ProductID = 2, ProductName = "Chang", Category = "Beverages",
            UnitPrice = 19.0000M, UnitsInStock = 17 },
          new Product{ ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments",
            UnitPrice = 10.0000M, UnitsInStock = 13 },
          new Product{ ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments"}
          
        };
            var list = (from x in productList
                        group x.Category by x.Category into g
                        select new { Category = g.Key, Count = g.Count() });
