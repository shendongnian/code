    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
      </configSections>
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
      </startup>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6, Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d"></provider>
        </providers>
      </entityFramework>
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient" />
          <add name="MySQL Data Provider" invariant="MySql.Data.MySqlClient" description=".Net Framework Data Provider for MySQL" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d" />
        </DbProviderFactories>
      </system.data>
      <connectionStrings>
        <add name="MyLocalDatabase" providerName="MySql.Data.MySqlClient" connectionString="server=localhost;port=3306;database=mycontext;uid=root;password=********" />
      </connectionStrings>
    </configuration>
