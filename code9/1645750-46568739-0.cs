    return 
        thisDataEntities.this_table
                        .Where(o => o.created_at >= start)
                        .Where(o => o.created_at <= end)
                        .Where(o => o.store_id == siteCode)
                        .Select(o => new
                                {
                                    OrderDate = o.created_at, 
                                    Id = o.entity_id,
                                    OrderDateFormatted = 
                                        SqlFunctions.DateName("yyyy", o.created_at) + "-" +
                                        SqlFunctions.DateName("mm", o.created_at) + "-" +
                                        SqlFunctions.DateName("dd", o.created_at)
                                })
                        .GroupBy(n => n.OrderDateFormatted) // format "2017-10-03"
                        .ToDictionary(g => g.First().OrderDate, g => g.Count());
