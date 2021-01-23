    protected void Application_Start()
     {
       // your code.
        // Warming up.
                Start(() =>
                {
                    using (var dbContext = new SomeDbContext())
                    { 
                        // Any request to db in current dbContext.
                        var response1 = dbContext.Addresses.Count();
                    }
                });
     }
    
     private void Start(Action a)
     {
        a.BeginInvoke(null, null);
     }
