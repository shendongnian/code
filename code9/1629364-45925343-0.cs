    // Exception is thrown if more than one is found. (id have to be unique)
    public Store Details() => db.Store.SingleOrDefault(s => s.Id == 1);
        
    // does not throw exceptions
    public Store Details() => db.Store.FirstOrDefault(s => s.Id == 1);
