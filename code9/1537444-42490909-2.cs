    static void Main(string[] args)
    {
        GlobalConfiguration.Configuration.UseSqlServerStorage("HangFireDBConnection");
        GlobalJobFilters.Filters.Add(new OneYearExpirationTimeAttribute());
        // ... more stuff ...
    }
