      <connectionStrings>
        <add name="DefaultConnection" connectionString="Data Source=your_server_name;User ID=your_user_id;Password=xxxxxxxx;"
          providerName="Oracle.ManagedDataAccess.Client" />
      </connectionStrings>
    
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          <provider invariantName="Oracle.ManagedDataAccess.Client"
            type="Oracle.ManagedDataAccess.EntityFramework.EFOracleProviderServices, Oracle.ManagedDataAccess.EntityFramework" />
        </providers>
      </entityFramework>
