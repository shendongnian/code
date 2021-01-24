    // Retrieving the secret from Azure Key Vault via a helper class
    var connectionString = await secret.Get("CosmosConnectionStringSecret");
    // Setting the AppSetting run-time with the secret value, because the Binder needs it
    ConfigurationManager.AppSettings["CosmosConnectionString"] = connectionString;
    
    // Creating an output binding
    var output = await binder.BindAsync<IAsyncCollector<MinifiedUrl>>(new DocumentDBAttribute("TablesDB", "minified-urls")
    {
        CreateIfNotExists = true,
        // Specify the AppSetting key which contains the actual connection string information
        ConnectionStringSetting = "CosmosConnectionString",
    });
    
    // Create the MinifiedUrl object
    var create = new CreateUrlHandler();
    var minifiedUrl = create.Execute(data);
    
    // Adding the newly created object to Cosmos DB
    await output.AddAsync(minifiedUrl);
