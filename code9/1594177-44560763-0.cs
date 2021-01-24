                var group = lst.GroupBy(l => l.Category)
                    .Select(x => new
                    {
                        Category = x.Key,
                        Class = string.Join(" OR ", x.Select(c => c.Class).Distinct()),
                        Ids = x.Select(c => c.Id).ToList()
                    }).ToList();
