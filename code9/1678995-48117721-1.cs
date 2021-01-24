    class AutoMapperTrail101_Console_OCP_Program
    {
        static void Main(string[] args)
        {
            //Initialize Automapper 
            AutoMapperConfiguration.Initialize();
            User user = new User()
            {
                Id = 7,
                Name = "Chandrahas J. Poojari"
            };
            EmployeeViewModel emv = new EmployeeViewModel();
            Mapper.Map(user, emv);
            Console.WriteLine("Employee Id :> " + emv.UserId);
            Console.WriteLine("Employee Name :> " + emv.UserName);
            Console.ReadLine();
            
        }
    }
    class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            //Mapper Initialize only once
            Mapper.Initialize(cfg =>
            {
                cfg.AllowNullDestinationValues = false;
                RegisterStandardMappings(types, cfg);
                RegisterReverseMappings(types, cfg);
                ReverseCustomMappings(types, cfg);
            });
        }
        private static void RegisterStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();
            foreach (var map in maps)
            {
                mce.CreateMap(map.Source, map.Destination);
            }
        }
        private static void RegisterReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select new
                        {
                            Source = t,
                            Destination = i.GetGenericArguments()[0]
                        }).ToArray();
            foreach (var map in maps)
            {
                mce.CreateMap(map.Source, map.Destination);
            }
        }
        private static void ReverseCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mce)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                              && !t.IsAbstract
                              && !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();
            foreach (var map in maps)
            {
                map.CreateMappings(mce);
            }
        }     
    }`
    interface IMapFrom<T> { }
    interface IMapTo<T> { }
    interface IHaveCustomMappings { void CreateMappings(IMapperConfigurationExpression mce); }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class EmployeeViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public void CreateMappings(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<User, EmployeeViewModel>()
                .ForMember("UserId", opt => { opt.MapFrom("Id"); })
                .ForMember("UserName", opt => { opt.MapFrom("Name"); });
        }
    }
