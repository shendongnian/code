    using (var db = new DataContext(dbConnectionString))
    {
       ids = new list<long> {"1","2",...};
       var data = (from item in db.GetTable<dataTable>()
                   where ids.Contains(item.ID)
                   select new 
                   {
                      name = item.name,
                      subIds = item.subitemIDs
                      ...
                   }).AsEnumerable()
                   .Select(x=> new customDataStructure
                       {
                          itemname = x.name,
                          subIds = x.subIds.ToList(),
                          ...
                       }).ToList();
    }
