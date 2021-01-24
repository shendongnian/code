    var ids = DbContextA.TableA.AsNoTracking().Select(item => item.FkToBId).ToList();
    var bInfo = DbContextB.TableB.AsNoTracking()
       .Where(item => ids.Contains(item.id)) 
       .ToDictionary(
             item => item.Id, 
             item => new { item.Col1, item.Col2, item.Col3 }
       );
    var aggrInfo = DbContextA.TableA.AsNoTracking()
       .ToList()
       .Select(item => new 
           { 
                AField = item, 
                Col1 = bInfo[item.FkToBId],
                Col2 = bInfo[item.FkToBId],
                Col3 = bInfo[item.FkToBId]
           };
