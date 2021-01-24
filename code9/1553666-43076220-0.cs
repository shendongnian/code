    <connectionStrings>
    <add name="ALDatabaseContext" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;port=3306;database=aldatabase;uid=root;password=root" />
    </connectionStrings>
  
    <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
      <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.9.9.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"></provider>
    </providers>
  
    </entityFramework>
  
    <system.data>
    <DbProviderFactories>
      <remove invariant="MySql.Data.MySqlClient" />
      <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.9.9.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
    </DbProviderFactories>
