    int Month = 0, Year= 0, Duration = 0;
                                var departments = stops 
                                    .Where(stop => stop.InitDate != null)
                                    .SelectMany(stop => new[] { Month = stop.InitDate.Month, Year = stop.InitDate.Year, Duration = stop.Duration })
                                    .GroupBy(dt => new { Month, Year }) 
                                    .OrderBy(g => g.Key.Month)
                                    .ThenBy(g => g.Key.Year) 
                                    .Select(g => new 
                                    { 
                                        Key = g.Key.Month, 
                                        Año = g.Key.Year, 
                                        Duration = g.Sum(v => Duration), 
                                        Count = g.Count() 
                                    });
