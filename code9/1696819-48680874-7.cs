    // Component is now static and the AppDbContext dependency is now supplied
    // using Method Injection. Since CustomerSearch is static, it can't have
    // a Constructor with dependencies.
    public static class CustomerSearch 
    {
        public static Customer[] Search(
            string lastName, // one or multiple parameters for the query
            AppDbContext context) // one or multiple dependencies
        {
            // use context to find customers and return
        }
    }
