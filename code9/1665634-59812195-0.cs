     ...
     RootLevelProp1 = "asd",
     RootLevelProp2 = "asd",
     Trades = b.Trades.OrderBy(c => c.Time).Select(c => new
                    {
                        c.Direction,
                        c.Price,
                        c.ShareCount,
                        c.Time
                    }) //<---- This was being returned as a queryable to the controller 
  
