    var subUsers = new List<Sub_User>()
    {
        new Sub_User { Name= "Unicorn" }
    };
    
    subUsers.ForEach(su => context.SubUsers.Add(su));
    
    context.SaveChanges();
