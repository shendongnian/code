    var result = myTable.AsEnumerable().GroupBy(x=> Featureid)
                                       .Select(item => new 
                                       {
                                           Feature = item.Key, 
                                           AssignedTo = string.Join(",", item.Select(a=>a.AssignedTo )),
                                           Stories = string.Join(",", item.Select(s=>s.Stories)),
                                           CompletedHrs= item.Sum(y=>y.CompletedHrs))
                                        });
