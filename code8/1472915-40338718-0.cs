    <configuration>
       <configSections>
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
              </configSections>
              <connectionStrings>
                <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\v11.0;Initial Catalog=aspnet-IHIPosterPresentationApp-20160104113839;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\aspnet-IHIPosterPresentationApp-20160104113839.mdf" providerName="System.Data.SqlClient" />
            
                <add name="IHIPosterAppEntities" connectionString="metadata=res://*/Models.IHIPosterAppDbEntityModel.csdl|res://*/Models.IHIPosterAppDbEntityModel.ssdl|res://*/Models.IHIPosterAppDbEntityModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=IHIPosterAppDev;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
              </connectionStrings>
            <entityFramework>
            <defaultConnectionFactory type="System.Data.Entity.Infrastructure.SqlConnectionFactory, EntityFramework" />
          </entityFramework>
        </configuration>
