	<configuration>
		<configSections> <!-- 1.  a section "entityFramework" -->
			<section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
		</configSections>
		
		
		<connectionStrings> <!-- 2. a connection string -->
			<add name="YourContext" connectionString="todo" providerName="System.Data.EntityClient" />
		</connectionStrings>
		
		<entityFramework> <!-- 3. entityFramework Tag -->
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
