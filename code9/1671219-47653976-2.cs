    var query = locations.GroupBy(
                x => x.Geography,
                (a, aGroup) => new
                {
                    A = a,
                    Items = aGroup.GroupBy(
                        x => x.Country,
                        (b, bGroup) => new
                        {
                            B = b,
                            Items = bGroup.GroupBy(
                                x => x.State,
                                (c, cGroup) => new
                                {
                                    B = c,
                                    Items = cGroup.Select(i => new {i.Id, i.OfficeName})
                                })
                        })
                });
