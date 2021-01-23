      <connectionStrings>
        <add name="MyDBContext" 
             connectionString="Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\MyAccessDB.MDB" 
             providerName="JetEntityFrameworkProvider" />
      </connectionStrings>
     <entityFramework>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
        <providers>
          <provider 
            invariantName="JetEntityFrameworkProvider" 
            type="JetEntityFrameworkProvider.JetProviderServices, JetEntityFrameworkProvider"/>
        </providers>
      </entityFramework>
      <system.data>
        <DBProviderFactories>
          <remove invariant="JetEntityFrameworkProvider"/>
          <add 
            invariant="JetEntityFrameworkProvider"
            name="Jet Entity Framework Provider"
            description="Jet Entity Framework Provider"
            type="JetEntityFrameworkProvider.JetProviderFactory, JetEntityFrameworkProvider"/>
        </DBProviderFactories>
      </system.data>
