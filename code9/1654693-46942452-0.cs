    var projected = offers.GroupBy(x => x.ProductName)
                                      .Select(x => new
                                      {
                                          ProductName = x.Key,
                                          Dates = x.GroupBy(y => y.TradingDate).ToList()
                                                                .Select(y => new
                                                                {
                                                                    TradingDate = y.Key,
                                                                    Times = y.GroupBy(z => z.HourOfDay).ToList()
                                                                                          .Select(zx => new
                                                                                          {
                                                                                              Time = zx.Key,
                                                                                              Items = zx.ToList()
                                                                                          })
                                                                })
                                      }).ToList();
