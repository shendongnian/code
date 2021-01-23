     public class UserProfile : Profile, IProfile
        {
            public UserProfile()
            {
                CreateMap<User, UserModel>();
                CreateMap<UserModel, User>();
            }
        }
    
    Now Create a seperate class e.g Mappings 
    
     public class Mappings
        {
            public static void RegisterMappings()
            {            
                var all =
                    Assembly
                        .GetEntryAssembly()
                        .GetReferencedAssemblies()
                        .Select(Assembly.Load)
                        .SelectMany(x => x.DefinedTypes)
                        .Where(type => typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));
    
                foreach (var ti in all)
                {
                    var t = ti.AsType();
                    if (t.Equals(typeof(IProfile)))
                    {
                        Mapper.Initialize(cfg =>
                        {
                            cfg.AddProfiles(t); // Initialise each Profile classe
                        });
                    }
                }         
            }
    
        }
    	
    	Now in MVC Core web Project in Startup.cs file , in constructor call Mapping class which will initialise 
    	all mappings at the time of application loading
    	
    	 Mappings.RegisterMappings();
