    var result = getvalues().GroupBy(item => new { item.Year, item.Month, item.Location }, 
                                     selector => selector.Value)
                            .Select(grouping => new
                            {
                                Year = grouping.Key.Year,
                                Month = grouping.Key.Month,
                                Location = grouping.Key.Location,
                                Total = grouping.Sum()
                            });
