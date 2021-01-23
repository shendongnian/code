    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    namespace ConsoleApplication28
    {
        class Program
        {
            static void Main(string[] args)
            {
                var json =
                    "{\r\n\"managedObjects\": [\r\n{\r\n  \"id\": \"13289\",      \r\n  \"name\": \"xxx\"      \r\n},\r\n{\r\n    \"id\": \"13290\",      \r\n  \"name\": \"yyy\" \r\n},\r\n{\r\n    \"id\": \"13289\",      \r\n  \"name\": \"xxx\" \r\n}]\r\n}";
                var managedObjectCollection = JsonConvert.DeserializeObject<ManagedObjectCollection>(json);
                var distinctManagedObjects = managedObjectCollection.managedObjects.GroupBy(a => a.id).Select(b => b.First());
                foreach (var distinctManagedObject in distinctManagedObjects)
                {
                    Console.WriteLine("Id: {0}, Name: {1}", distinctManagedObject.id, distinctManagedObject.name);
                }
                Console.ReadLine();
            }
            class ManagedObjectCollection
            {
                public IEnumerable<ManagedObject> managedObjects { get; set; }
            }
            class ManagedObject
            {
                public int id { get; set; }
                public string name { get; set; }
            }
        }
    }
