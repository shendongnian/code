    <configuration>
      <configSections>
        <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
    	[...]
      </configSections>
    
      <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="Data Source=.; Integrated Security=True; MultipleActiveResultSets=True;" />
          </parameters>
        </defaultConnectionFactory>
        [...]
        <providers>
          <provider invariantName="MySql.Data.MySqlClient" type="MySql.Data.MySqlClient.MySqlProviderServices, MySql.Data.Entity.EF6" />
    	  [...]
        </providers>
        [...]
      </entityFramework>
      [...]
      <system.data>
        <DbProviderFactories>
          <remove invariant="MySql.Data.MySqlClient" />
          <add description=".Net Framework Data Provider for MySQL" invariant="MySql.Data.MySqlClient" name="MySQL Data Provider" type="MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data" />
        </DbProviderFactories>
      </system.data>
      [...]
    </configuration>
