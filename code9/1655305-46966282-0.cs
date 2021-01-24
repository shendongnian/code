           var prodsalesbygender = context.Orders
                                          .GroupBy(o => new
                                          {
                                              Gender = o.Person.Gender
                                          })
                                          .Select(g => new
                                          {
                                              Gender = g.Key,
                                              Products = g.Select(o => o.OrderProducts
                                                                        .GroupBy(op => op.Product)
                                                                        .Select(op => new
                                                                        {
                                                                            ProductName = op.Key.Name,
                                                                            Qty = op.Sum(op2 => op2.Qty),
                                                                            Price = op.Select(x => x.Product.Price)
                                                                                      .First(),
                                                                        })
                                                                        .Select(x => new
                                                                        {
                                                                            ProducName = x.ProductName,
                                                                            Qty = x.Qty,
                                                                            Price = x.Price,
                                                                            TotalPrice = x.Qty * x.Price
                                                                        }))
                                          });
