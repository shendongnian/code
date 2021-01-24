    var flatList = mainList.SelectMany(m => 
        m.Owners.Select(o => 
            new FlatList { 
                  Id = m.Id, 
                  Name = m.Name, 
                  OwnerId = o.Id,
                  OwnerName = o.Name
             })).ToList()
