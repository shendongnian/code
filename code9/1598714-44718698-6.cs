    var result = products
                .SelectMany(x => x.CategoryGroups)
                .GroupBy(x => x.CategoryGroupId)
                .Select(x => new CategoryGroup
                             {
                                 Categories = x.Values
                                               .SelectMany(y => y.Categories)
                                               .Distinct(y => y.CategoryId)
                                               .OrderBy(y => y.CategoryId)
                                               .ToList(),
                                 CategoryGroupId = x.Key,
                                 Name = x.Values.First().Name
                             })
                .OrderBy(x => x.CategoryGroupId)
                .ToList();
