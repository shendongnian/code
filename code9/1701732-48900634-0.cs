    var query = (from finalq in
                    (
                        from cat in categories
                        join procat in
                            // Join [ProductCategories] with [Products] first
                            (
                                from pc in productcategories
                                join p in products on pc.ProductId equals p.Id
                                where p.IsAvailable == "True"
                                select new
                                {
                                    CategoryId = pc.CategoryId,
                                    ProductId = p.Id,
                                    ProductPrice = p.Price
                                }
                            )
                        // And then join the result with [Categories]
                        on cat.Id equals procat.CategoryId
                        select new
                        {
                            CategoryId = cat.Id,
                            CategoryDescription = cat.Description,
                            ProductPrice = procat.ProductPrice
                        }
                    )
                // Then aggregate it to get the final result
                group finalq by new { finalq.CategoryId, finalq.CategoryDescription } into finalGroup
                orderby finalGroup.Average(c => c.ProductPrice) descending
                select new
                {
                    CategoryId = finalGroup.Key.CategoryId,
                    CategoryDescription = finalGroup.Key.CategoryDescription,
                    ProductPrice = finalGroup.Average(c => c.ProductPrice),
                    NumberOfAvailableProducts = finalGroup.Count()
                }
            )
            // And take the TOP 3 rows (I know it's ugly but I don't have a choice)
            .Take(3);
