            allBasketProducts = new List<BasketProduct>()
            {
                new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = 1,
                        Price = 5,
                    },
                    Quantity = 2,
                    SubTotal = 2,
                },
                new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = 1,
                        Price = 5,
                    },
                    Quantity = 4,
                    SubTotal = 2,
                },
                new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = 2,
                        Price = 10,
                    },
                    Quantity = 3,
                    SubTotal = 2,
                },
                new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = 3,
                        Price = 20,
                    },
                    Quantity = 3,
                    SubTotal = 2,
                },
                new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = 2,
                        Price = 20,
                    },
                    Quantity = 3,
                    SubTotal = 2,
                }
            };
            allBasketProducts = allBasketProducts
                .GroupBy(x => x.Product.ID)
                .Select(y => new BasketProduct()
                {
                    Product = new ProductItem()
                    {
                        ID = y.First().Product.ID,
                        Item = y.First().Product.Item,
                        Description = y.First().Product.Description,
                        ImagePath = y.First().Product.ImagePath,
                        Price = y.First().Product.Price
                    },
                    Quantity = y.Sum(z => z.Quantity),
                    SubTotal = y.Sum(z => z.SubTotal)
                }).ToList();
