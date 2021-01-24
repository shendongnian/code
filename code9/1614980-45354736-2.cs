    ProductSumUp.ItemsSource = _showProducts;
    bool prodExists = false;
    foreach (ProductGroup prodz in _showProducts)
    {
         if (prodz.groupedProduct.ID == prod.ID)
            {
              prodExists = true;
            }
    }
    if (!prodExists)
    {
        ProductGroup prodGroup = new ProductGroup();
        prodGroup.groupedProduct = prod;
        prodGroup.Price = prod.Price;
        prodGroup.Count = 1;
        prodGroup.PriceSum += prod.Price;
        _showProducts.Add(prodGroup);
    }
     else
    {
        ProductGroup pgroup = _showProducts.First(x => x.groupedProduct.ID == prod.ID);
        if (pgroup != null)
        {
            pgroup.Count++;
            pgroup.PriceSum += pgroup.Price;
        }
    }
