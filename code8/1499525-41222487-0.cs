    var result = list1.Select(x => new 
                { 
                Section = x.Section, 
                BeginningValue = x.BeginningValue, 
                EndingValue = list2.Any(y => y.Section == x.Section) ? 
                              list2.First(y => y.Section == x.Section).EndingValue : 
                              0 
                }).ToList();
