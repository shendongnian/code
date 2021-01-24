    using Microsoft.Azure.Management.Sql.Models;
    using Microsoft.Azure.Management.Sql;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    private void RestoreToPointInTime()
    {
	    var token = GetToken("{tenantId}", "{applicationId}", "{appliactionSecret}");
        var sqlMgmtClient = new SqlManagementClient(new Microsoft.Rest.TokenCredentials(token.AccessToken)) { SubscriptionId = "{SubscriptionId}" };
	    var myDb = sqlMgmtClient.Databases.Get("RestoreTest", "testsqlserver", "TestDB");
	    var newDb = new Database
	    {
		    Location = myDb.Location,
		    CreateMode = CreateMode.PointInTimeRestore,
		    RestorePointInTime = myDb.EarliestRestoreDate.Value,
		    SourceDatabaseId = myDb.Id
	    };
	    sqlMgmtClient.Databases.CreateOrUpdate("RestoreTest", "testsqlserver", "TestNewDB", newDb);
    }
    private static AuthenticationResult GetToken(string tenantId, string applicationId, string applicationSecret)
    {
	    AuthenticationContext authContext = new AuthenticationContext("https://login.windows.net/" + tenantId);
	    return authContext.AcquireToken("https://management.core.windows.net/", new ClientCredential(applicationId, applicationSecret));
    }
