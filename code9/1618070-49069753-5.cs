    <?xml version="1.0" encoding="utf-8"?>
    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework" requirePermission="false" />
    	[...]
      </configSections>
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
          [...]
        </providers>
      </entityFramework>
      [...]
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient" />
          <add description=".Net Framework Data Provider for MySQL" invariant="MySql.Data.MySqlClient" name="MySQL Data Provider" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data" />
        </DbProviderFactories>
      </system.data>
      [...]
      <startup>
        <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.7.1" />
      </startup>
    </configuration>
