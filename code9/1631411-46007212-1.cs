    // using Z.EntityFramework.Plus; // Don't forget to include this.
    var ctx = new EntitiesContext();
    
    // CREATE a pending list of future queries
    var futureCountries = ctx.Countries.Where(x => x.IsActive).Future();
    var futureStates = ctx.States.Where(x => x.IsActive).Future();
    
    // TRIGGER all pending queries in one database round trip
    // SELECT * FROM Country WHERE IsActive = true;
    // SELECT * FROM State WHERE IsActive = true
    var countries = futureCountries.ToList();
    
    // futureStates is already resolved and contains the result
    var states = futureStates.ToList();
