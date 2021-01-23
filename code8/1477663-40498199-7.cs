    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace CMS
    {
        class mySettings
        {
            public static string GetDBConnectionString()
            {
                // **************************************************
                // This is my "ConnectionString" from App.config file.
                // <connectionStrings>
                //      <add name="CMSEntities" 
                //          connectionString=
                //              "metadata=res://*/CMS.csdl|res://*/CMS.ssdl|res://*/CMS.msl
                //                  ;provider=System.Data.SqlClient
                //                  ;provider connection string=&quot
                //                  ;data source=MY-PC\SQLEXPRESS
                //                  ;initial catalog=CMS
                //                  ;user id=sa
                //                  ;password=12345687
                //                  ;MultipleActiveResultSets=True
                //                  ;App=EntityFramework
                //              &quot;"
                //      providerName="System.Data.EntityClient" />
                //</connectionStrings>
                // **************************************************
    
                string metaData = "res://*/CMS.csdl|res://*/CMS.ssdl|res://*/CMS.msl";
                string providerName = "System.Data.SqlClient";
                
                string dataSource = @"MY-PC\SQLEXPRESS";
                string databaseName = "CMS"; // = InitialCatalog
                string userID = "sa";
                string password = "12345687";
                string appName = "EntityFramework";
    
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
                SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();
    
                // = = = = = = = = = = = = = = = =
                sqlBuilder.DataSource = dataSource;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.MultipleActiveResultSets = true;
                sqlBuilder.UserID = userID;
                sqlBuilder.Password = password;
                sqlBuilder.ApplicationName = appName;
    
    
                // = = = = = = = = = = = = = = = =
                entityBuilder.Provider = providerName;
                entityBuilder.Metadata = metaData;
                entityBuilder.ProviderConnectionString = sqlBuilder.ConnectionString;
    
                return entityBuilder.ToString();
            }
        }
    }
