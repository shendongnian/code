    <connectionStrings>
    <add name="BlogDbContext" connectionString="Data Source=DESKTOP-I3K90LQ\SQL2016;Initial Catalog=CodeFirstDemo;Integrated Security=SSPI;" providerName="System.Data.SqlClient"/>
    </connectionStrings>
    <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework">
    <parameters>
    <parameter value="Data Source=localhost; Integrated Security=True; MultipleActiveResultSets=True"/>
    </parameters>
    </defaultConnectionFactory>
    <providers>
    <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
    </entityFramework>
