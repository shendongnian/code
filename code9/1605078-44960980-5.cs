            var list3 = list1.Union(list2);
                             .GroupBy(a => a.Zone)
                             .Select(group => new Datum 
                                              {
                                                  Zone = group.Key, 
                                                  Count = group.Sum(row => row.Count) 
                                              }
                                    );
