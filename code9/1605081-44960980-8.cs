            var list3 = list1.Concat(list2);
                             .GroupBy(a => a.Zone)
                             .Select(group => new Datum 
                                              {
                                                  Zone = group.Key, 
                                                  Count = group.Sum(row => row.Count) 
                                              }
                                    );
