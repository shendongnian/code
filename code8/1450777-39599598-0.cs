    // ...
    
    Console.WriteLine(context.Entry(foo).Collection(e => e.FooBars).IsLoaded); // false
    //foo.FooBars is already populated, so 1 is returned and no database query is executed.
    int count = foo.FooBars.Count;
    
    // Cache the collection property into a variable
    var foo_FooBars = foo.FooBars;
    
    context.SaveChanges();
    
    Console.WriteLine(context.Entry(foo).State); // Unchanged!
    Console.WriteLine(context.Entry(foo).Collection(e => e.FooBars).IsLoaded); // false
    
    // The collection is still there, this does not trigger database query
    count = foo_FooBars.Count;
    // This causes a new query against the database
    count = foo.FooBars.Count;
