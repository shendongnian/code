      <connectionStrings>
        <add name="BotDataEntities" providerName="System.Data.SqlClient" connectionString="Server=[YourDatabaseServerName];Initial Catalog=[YourDatabaseName];Persist Security Info=False;User ID=[YourDatabaseUserId];Password=[YourDatabaseUserPassword];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" />
      </connectionStrings>
    <entityFramework>
    	<defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
    <parameters>
        <parameter value="mssqllocaldb" />
      </parameters>
     </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
    </entityFramework>
