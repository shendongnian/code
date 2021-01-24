    namespace JsonDEMO
    {
        public class Rootobject
        {
            public Foo foo { get; set; }
        }
    
        public class Foo
        {
            public Resources Resources { get; set; }
        }
    
        public class Resources
        {
            public string resourceUri { get; set; }
            public string location { get; set; }
            public Tags tags { get; set; }
        }
    
        public class Tags
        {
            public string displayName { get; set; }
            public string containerregistry { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                string jsonString = "{'foo':{'Resources':{'resourceUri':'/xf/b/rs/RA-a-675e/fo/age/s/m78','location':'us','tags':{'displayName':'As storage','containerregistry':'dd'}}}}";
    
                var deserializedRootObject = Newtonsoft.Json.JsonConvert.DeserializeObject<Rootobject>(jsonString);
    
                System.Console.WriteLine(deserializedRootObject.foo.Resources.resourceUri);
                System.Console.WriteLine(deserializedRootObject.foo.Resources.location);
                System.Console.WriteLine(deserializedRootObject.foo.Resources.tags.displayName);
                System.Console.WriteLine(deserializedRootObject.foo.Resources.tags.containerregistry);
            }
        }
    }
