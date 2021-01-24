    var result = locations.GroupBy(
                    x => x.Geography,
                    (a, aGroup) => new
                    {
                        A = a,
                        Items = aGroup.GroupBy(
                            x => x.Country,
                            (b, bGroup) => new
                            {
                                B = b,
                                Items = bGroup
                            })
                    }
                );
