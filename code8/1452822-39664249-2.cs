     var results = ctx.Searches.Where(s => s.FirstName == "D")
                                        .AsEnumerable().GroupBy(x => x.PersonId)
                                        .Select(p => new SearchResult{
                                                        FirstName = p.FirstOrDefault().FirstName,
                                                        PersonId = p.Key.Value,
                                                        CId = p.Select(z => z.CId).ToArray()
                                                    }).ToList();
