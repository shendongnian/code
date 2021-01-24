    allBasketProducts
        .GroupBy(x => x.Product.ID)
        .Select(y => new BasketProduct
			{
				Quantity = y.Sum(z => z.Quantity),
				SubTotal = y.Sum(z => z.SubTotal),
				Product = new ProductItem
				{
					ID = y.First().Product.ID,
					Item = y.First().Product.Item,
					Description = y.First().Product.Description,
					ImagePath = y.First().Product.ImagePath,
					Price = y.First().Product.Price
				}
            }).ToList();
