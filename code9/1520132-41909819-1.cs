       <?xml version="1.0" encoding="utf-8"?>
      <configuration>
        <configSections>
          <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
          <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
        </configSections>
        <connectionStrings>         
          <add name="EncryptedConnection" connectionString="qIhXH2MDWohYjOPJ3BiA7A4E70kRjRW3aSOMixpASFHu1oyak2YEMO3BTaRr3s5eVtuvi5dY07vK+PUm1xFZ6D1XT/qJjDvrs1SpbTHe45g=" providerName="System.Data.SqlClient" />
        </connectionStrings>
        <startup>
          <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
        </startup>
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
      </configuration>
