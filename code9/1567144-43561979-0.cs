    list1.Select(x => x new {
                               Id = x.Id, 
                               Date = x.Date, 
                               Attribute1 = x.Attribute1, 
                               Attribute2 = null, 
                               Attribute3 = null
                            }
                 ).Union(list2.Select(x =new {
                               Id = x.Id, 
                               Date = x.Date, 
                               Attribute1 = null, 
                               Attribute2 = x.Attribute2, 
                               Attribute3 = x.Attribute3
                         }));
