    var result = myTable.AsEnumerable().GroupBy(x=> x["Featureid"])
                                       .Select(item => new 
                                       {
                                           Feature = item.Key, 
                                           AssignedTo = string.Join(",", item.Select(a=>a["AssignedTo"])),
                                           Stories = string.Join(",", item.Select(s=>s["storyid"])),
                                           CompletedHrs= item.Sum(y=>y["CompletedHrs"]))
                                        });
