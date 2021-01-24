     var query=context.Users.Where(r => r.IsDeleted == IsDeleted);
     foreach(var u in query)
     {
      context.Entry(u) 
             .Collection(b => b.UserRoles) 
             .Query() 
             .Where(y=>!y.IsDeleted)
             .Load(); 
     }
