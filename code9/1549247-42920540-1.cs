    public string GetConnectionString(string initialCatalog)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.InitialCatalog = initialCatalog;
        // Set another connection parameters
        return builder.ToString();
    }
