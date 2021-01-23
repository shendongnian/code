            foreach (var item in db.Product.OrderBy(p => p.ProductName))
            {
                var mp = new Models.Product.ModelProduct();
                mp.SectorName = item.ProductName;
                mp.ProductID = item.ProductID;
                mp.DetailsUrl = item.Details;
                m.AllProducts.Add(mp);
  
                if(condition) //if it is needed
                   break;
            }
