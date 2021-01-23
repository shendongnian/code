    var allItems = dbContext.Items
                .Select(x => new {
                    Id = x.Id,
                    PropertyA = x.PropertyA,
                    Children = x.Children.Select(c => new {
                        Id = c.Id,
                        PropertyA = c.PropertyA,
                    })
                })
                .AsEnumerable()
                .Select(x => new Projection() {
                    Id = x.Id,
                    PropertyA = x.PropertyA,
                    Children = x.Children.Select(c => new Projection {
                        Id = c.Id,
                        PropertyA = c.PropertyA
                    }).ToList()
                }).ToList();
