                var grouped = ttcaList.GroupBy(tv => new DateTimeOffset(
                                        tv.Time.Year, 
                                        tv.Time.Month, 
                                        tv.Time.Day, 
                                        tv.Time.Hour, 
                                        tv.Time.Minute - tv.Time.Minute % 10, 
                                        0, 
                                        tv.Time.Offset))
                .Select(g =>
                  g.OrderBy(tv => tv.Time).ToList()
                ).ToList();
