      <entityFramework>
        <providers>
          <provider invariantName="Devart.Data.PostgreSql" type="Devart.Data.PostgreSql.Entity.PgSqlEntityProviderServices,Devart.Data.PostgreSql.Entity.EF6, Version=7.6.743.0, Culture=neutral, PublicKeyToken=09af7300eec23701" />
        </providers>
      </entityFramework>
      
      <system.data>
        <DbProviderFactories>
          <remove invariant="Devart.Data.PostgreSql" />
          <add name="dotConnect for PostgreSQL" invariant="Devart.Data.PostgreSql" description="Devart dotConnect for PostgreSQL" type="Devart.Data.PostgreSql.PgSqlProviderFactory, Devart.Data.PostgreSql, Version=7.6.743.0, Culture=neutral, PublicKeyToken=09af7300eec23701" />
        </DbProviderFactories>
      </system.data>
  
  
