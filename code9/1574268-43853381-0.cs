    collectionName.Aggregate()
                    .Match(filter)
                    .Project(x => new {x.CustomerType, x.ProductName, x.SubscriptionId })
                    .Group(x => new { x.ProductName, x.CustomerType }, g => new 
                    {
                        Id = g.Key,
                        ActiveTrials = g.Count()
                    })
                    .Project(x => new ActiveTrialsByProduct()
                    {
                        CustomerType = x.Id.CustomerType,
                        Product = x.Id.ProductName,
                        ActiveTrials = x.ActiveTrials
                    }).ToList();
