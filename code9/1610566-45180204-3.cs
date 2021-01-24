    string clientId = "xxxxxxx";
    string secretKey = "xxxxxxx";
    string tenantId = "xxxxxxx";
    var credentials = new AzureCredentials(new ServicePrincipalLoginInformation { ClientId = clientId, ClientSecret = secretKey }, tenantId, AzureEnvironment.AzureGlobalCloud);
    var azure = Azure
                .Configure()
                .Authenticate(credentials)
                .WithDefaultSubscription();
    var serverName = "tomtestsqlazure";//test sql name
    var regionName = Region.AsiaEast.ToString(); //region name
    var administratorLogin = "tom";
    var administratorPassword = "xxxxxxx";
    var rgName = "xxxxx"; //resource group name
    var elasticPoolName = "testelastic"; 
    var elasticPoolEdition = "standard";
    ISqlServer sqlServer =  azure.SqlServers
    .Define(serverName)
    .WithRegion(regionName)
    .WithExistingResourceGroup(rgName)
    .WithAdministratorLogin(administratorLogin)
    .WithAdministratorPassword(administratorPassword)
    .WithNewElasticPool(elasticPoolName, elasticPoolEdition)
    .CreateAsync().Result;
