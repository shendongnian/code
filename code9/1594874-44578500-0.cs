    public class Foo
    {
        public ObjectId Id;
        public double Price = 69.99;
        public Attribute[] Attributes = {
            new Attribute { Name = "Color", Value = "Grey" },
            new Attribute { Name = "Gender", Value = "Men" }
        };
    }
    
    public class Attribute
    {
        public string Name;
        public string Value;
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient();
            var collection = client.GetDatabase("test").GetCollection<Foo>("test");
            collection.InsertOne(new Foo());
            var distinctItems = collection.Distinct(new StringFieldDefinition<Foo, string>("Attributes.Name"), FilterDefinition<Foo>.Empty).ToList();
            foreach (var distinctItem in distinctItems)
            {
                Console.WriteLine(distinctItem);
                // prints:
                // Color
                // Gender
            }
            Console.ReadLine();
        }
    }
