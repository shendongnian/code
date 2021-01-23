    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("> Enter your serach term: ");
            var searchTerm = Console.ReadLine();
            using (var session = DocumentStoreHolder.Instance.OpenSession())
            {
                var devices = session.Query<Device>()
                    .Where(x => x.MyStringValues.Any(s => s == searchTerm))
                    .ToList();
                foreach (var device in devices)
                {
                    Console.WriteLine(device.Id);
                    foreach (var s in device.MyStringValues)
                        Console.WriteLine($" - {s}");
                }
            }
            Console.ReadKey();
        }
    }
    public class Device
    {
        public Device()
        {
            MyStringValues = new List<string>();
        }
        public string Id { get; set; }
        public IList<string> MyStringValues { get; set; }
    }
    public class Devices_ByStringValue : AbstractIndexCreationTask<Device>
    {
        public override string IndexName => "Devices/ByStringValue";
        public Devices_ByStringValue()
        {
            Map = devices => from device in devices
                              select new { device.MyStringValues };
        }
    }
    public class DocumentStoreHolder
    {
        static DocumentStoreHolder()
        {
            Instance = new DocumentStore
            {
                Url = "http://localhost:8080/",
                DefaultDatabase = "RavenTest",
            };
            Instance.Initialize();
            Serializer = Instance.Conventions.CreateSerializer();
            Serializer.TypeNameHandling = TypeNameHandling.All;
            Instance.Initialize();
            IndexCreation.CreateIndexes(typeof(Devices_ByStringValue).GetTypeInfo().Assembly, Instance);
        }
        public static DocumentStore Instance { get; }
        public static JsonSerializer Serializer { get; }
    }
