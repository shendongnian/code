    var connectionString = ConfigurationManager.ConnectionStrings["MyConName"];
    var providerName = connectionString.ProviderName;
    var factory = DbProviderFactories.GetFactory(providerName);
    var connection = factory.CreateConnection();
    connection.ConnectionString = connectionString.ConnectionString;
    connection.Open();
