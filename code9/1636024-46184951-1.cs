    <entityFramework>
        <contexts>
          <context type="BookMe.Domain.Concrete.BookMeContext, BookMe.Domain">
            <databaseInitializer type="BookMe.Domain.Concrete.BookMeInitializer, BookMe.Domain" />
          </context>
        </contexts>
        <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
          <parameters>
            <parameter value="mssqllocaldb" />
          </parameters>
        </defaultConnectionFactory>
        <providers>
          <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
        </providers>
      </entityFramework>
