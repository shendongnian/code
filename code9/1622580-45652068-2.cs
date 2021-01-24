    var result = s.Results
                    .SelectMany(c => c.List, (b, c) => new {b.Name, DObj = c})
                    .GroupBy(g => g.DObj.AllowedAccess)
                    .ToDictionary(k=> k.Key,
                        c =>
                            new {
                                c.Key,
                                List =
                                    c.GroupBy(cg => cg.Name)
                                        .Select(
                                            x => new GroupedObject {Name = x.Key, List = x.Select(l => l.DObj).ToList()})
                                        .ToList()
                            });
