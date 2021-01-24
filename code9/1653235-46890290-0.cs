    public class NHConnection
    {
     private string _connectionString;
     private Type _markerType;
     
     public WithConnectionString(string connectionString)
     {
      _connectionString = connectionString;
      return this;
     }
     
     public NHConnection UseMarkerAssembly(Type markerAssembly)
        {
            _markerType = markerAssembly;
            return this;
        }
    
     public ISessionFactory Build()
     {
       var config = Fluently.Configure()
                .Database(_connectionString) // <-- Connection string 2
                
    			//.Mappings(AutoMapping.Configurations) consider using a configurable markerAssembly for each db like:
    			.Mappings(m =>
                {
    				m.FluentMappings.AddFromAssembly(markerType.Assembly)
    			});
    				 
                .ExposeConfiguration(cfg => cfg.SetProperty("connection.isolation", "ReadCommitted"))
                .ExposeConfiguration(cfg => cfg.SetProperty(Environment.CommandTimeout, c.Resolve<IConfig>().SqlCommandTimeoutSeconds.ToString()))
                .BuildConfiguration());
        return config.BuildSessionFactory();
     }
    }
    
     //Register the FactoryBuilder in your Autofac Module
     
     builder.Register(x => new NHConnection().WithConnectionString("your;connectionString:toDb1").UseMarkerAssembly(typeof(MarkerTypeAssemblyForDB1Mappings)).Build()).Keyed<ISessionFactory>("db1").SingleInstance();
     builder.Register(x => new NHConnection().WithConnectionString("your;connectionString:toDb2").UseMarkerAssembly(typeof(MarkerTypeAssemblyForDB2Mappings)).Build()).Keyed<ISessionFactory>("db2").SingleInstance();
     builder.Register<Func<string, ISessionFactory>>(c =>
            {
                IComponentContext co = c.Resolve<IComponentContext>();
                return db => co.ResolveKeyed<ISessionFactory>(db);
            });     
    	  
    	 
     // Resolve the factory for DB 1, 2 or 3 in your query / repo class		 
    	  
     public class QueryClass{
       private _factoryLookUp Func<string, ISessionFactory> FactoryLookup { get; set; }
       public void QueryClass(Func<DataDomain, ISessionFactory> factoryLookup)
       {
        _factoryLookUp = factoryLookup; 
       }
       
       public executeYourQuery()
       {
         using(var session = factoryLookup("db1").OpenSession)
    	 {
    	   ....
    	 }
       }
       
     }
     
