    // ...
    
    context.SaveChanges();
    
    context.Entry(foo).Collection(e => e.FooBars).IsLoaded = true;
    context.Entry(bar).Collection(e => e.FooBars).IsLoaded = true;
    // No new query against the database :)
    count = foo.FooBars.Count;
 
