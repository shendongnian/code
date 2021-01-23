    public abstract class Bar
    {
        public string Field1 { get; set; }
    }
    
    public class Foo1bar : Bar
    {
        // members
    }
    
    public class Foo2bar : Bar
    {
        // members
    }
    
    public class BarContract
    {
        public string Field1 { get; set; }
    
        // this will use existing someClass.Description field
        public string Field2Description { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfiguration.Init();
    
            var foo1 = new Foo1bar {Field1 = "One"};
            var barContract1=AutoMapperConfiguration.Mapper.Map<Foo1bar, BarContract>(foo1);
            Console.WriteLine("barContract1.Field1: " + barContract1.Field1);
    
            var foo2 = new Foo2bar {Field1 = "Two"};
            var barContract2=AutoMapperConfiguration.Mapper.Map<Foo2bar, BarContract>(foo2);
            Console.WriteLine("barContract2.Field1: " + barContract2.Field1);
    
            Console.ReadLine();
        }
    
        public static class AutoMapperConfiguration
        {
            public static void Init()
            {
                MapperConfiguration = new MapperConfiguration(cfg =>
                {
                    var types = Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => !string.IsNullOrEmpty(type.Namespace) &&
                                        type.BaseType != null &&
                                        type.BaseType == typeof(Bar));
                    foreach (Type type in types)
                    {
                        cfg.CreateMap(type, typeof(BarContract));
                    }
                });
    
                Mapper = MapperConfiguration.CreateMapper();
            }
    
            public static IMapper Mapper { get; private set; }
    
            public static MapperConfiguration MapperConfiguration { get; private set; }
        }
    }
