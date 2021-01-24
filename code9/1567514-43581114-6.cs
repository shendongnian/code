    var result = (from item in getvalues()
                    group item.Value by new { item.Year, item.Month, item.Location } into g
                    select new {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        Location = g.Key.Location,
                        Total = g.Sum()
                    });
