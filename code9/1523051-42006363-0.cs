    public class Program
    {
        public static void Main()
        {
            Initialize();
    
            var source = new Parent
            {
                Locations = new List<Location>
                {
                    new Location {LocationId = 1, Name = "One"},
                    new Location {LocationId = 2, Name = "Two"},
                    new Location {LocationId = 3, Name = "Three"},
                }
            };
    
            var destination = Mapper.Map<Parent, Destination>(source);
    
            Console.ReadLine();
        }
    
        public static void Initialize()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Parent, Destination>()
                    .ForMember(dest => dest.DelimitedLocations, mo => mo.MapFrom(src =>
                        src.Locations != null
                            ? string.Join(",", src.Locations.Select(x => x.LocationId).ToList())
                            : ""));
            });
            Mapper = MapperConfiguration.CreateMapper();
        }
    
        public static IMapper Mapper { get; private set; }
    
        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
    
    public class Parent
    {
        public List<Location> Locations { get; set; }
    }
    
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }
    }
    
    public class Destination
    {
        public string DelimitedLocations { get; set; }
    }
