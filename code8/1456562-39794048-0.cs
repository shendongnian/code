        var query1 = (from a in dbContext.Table1 
                      where a.email == someEmail 
                      select a.Table1K);
        var query2 = (from a in dbContext.Table2 
                      where a.emailAddrerss == someEmail 
                      select a.Table2K);
        var query3 = (from a in dbContext.Table3 
                      where a.email == someEmail 
                      select a.Table3K);
    
        if ( query2.Any() || query3.Any() )
        {
           return false;
        }
        
        var x = query1.SingleOrDefault();
        if(x != null)
        {
           // do some stuff with that x value ... 
        }
