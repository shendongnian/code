    public class Program
    {
        public static void Main(string[] args)
        {
            Foo foo = new Foo
            {
                Model = new { link = "http://www.google.com", name = "John" },
                Widget1 = new Doodad { Name = "Sprocket", Size = 10 },
                Widget2 = new Thingy { Name = "Coil", Strength = 5 }
            };
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ContractResolver = OmitTypeNamesOnDynamicsResolver.Instance,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(foo, settings);
            Console.WriteLine(json);
            Console.WriteLine();
            Foo foo2 = JsonConvert.DeserializeObject<Foo>(json, settings);
            Console.WriteLine(foo2.Model.link);
            Console.WriteLine(foo2.Model.name);
            Console.WriteLine(foo2.Widget1.Name + " (" + foo2.Widget1.GetType().Name + ")");
            Console.WriteLine(foo2.Widget2.Name + " (" + foo2.Widget2.GetType().Name + ")");
        }
    }
    public class Foo
    {
        public dynamic Model { get; set; }
        public AbstractWidget Widget1 { get; set; }
        public AbstractWidget Widget2 { get; set; }
    }
    public class AbstractWidget
    {
        public string Name { get; set; }
    }
    public class Thingy : AbstractWidget
    {
        public int Strength { get; set; }
    }
    public class Doodad : AbstractWidget
    {
        public int Size { get; set; }
    }
