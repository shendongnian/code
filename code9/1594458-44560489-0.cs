     var configNameEf = string.IsNullOrEmpty(configConnectionStringName)
     ? source.GetType().Name 
     : configConnectionStringName;
            // add a reference to System.Configuration
            var entityCnxStringBuilder = new EntityConnectionStringBuilder
                (System.Configuration.ConfigurationManager
                    .ConnectionStrings[configNameEf].ConnectionString);
