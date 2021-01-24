    DbContext source; //i assumed you created on
    
     var entitysb= new EntityConnectionStringBuilder
                    (System.Configuration.ConfigurationManager
                        .ConnectionStrings["EntityConnection"].ConnectionString);
    
    var sqlsb = new SqlConnectionStringBuilder
                    (entitysb.ProviderConnectionString);
    source.Database.Connection.ConnectionString 
                    = sqlsb.ConnectionString;
