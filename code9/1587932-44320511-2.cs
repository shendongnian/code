    _db.Lists
    .Select (
      i => 
         new  
         {
            i = i, 
            p = _db.ListUsers
               .Where (p2 => i.ListID == p2.ListID))
               .Take(1)
               .FirstOrDefault()
         })
      .Select (
      results => 
         new  
         {
            ListID= results.i.ListID,
	        ListName = results.i.ListName,
            CustomField2 = results.p.CustomField2
         }
   )
