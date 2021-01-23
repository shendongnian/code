    foreach (var item in db.Product.Where(p => p.ProductID.Equals(requiredID)).OrderBy(p => p.ProductName))
        {
            var mp = new Models.Product.ModelProduct();
            mp.SectorName = item.ProductName;
            mp.ProductID = item.ProductID;
            mp.DetailsUrl = item.Details;
            m.AllProducts.Add(mp);
        }
