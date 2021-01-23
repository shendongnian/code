    using Mapster; //Reference your package
    
    
    namespace YourApplication
    {
        public class Startup
        {
            public Startup(IHostingEnvironment env)
            {
               //His previous codes ...
                
               //Place this code
                TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetEntryAssembly());
            }
        }
    }
