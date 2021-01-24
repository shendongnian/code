    public class Program
    {
        static void Main(string[] args)
        {
            var collection = new MongoClient().GetDatabase("test").GetCollection<Test>("test");
    
            // insert test record
            collection.InsertOne(
                new Test
                {
                    PartData = new ObservableCollection<DataElement>(
                        new ObservableCollection<DataElement>
                        {
                            new DataElement(),
                            new DataElement()
                        }),
                    SensorData = new ObservableCollection<DataElement>(
                        new ObservableCollection<DataElement>
                        {
                            new DataElement(),
                            new DataElement()
                        }),
                    TestString = "SomeString"
                });
    
            // here, we use reflection to find the relevant properties
            var allPropertiesThatWeAreLookingFor = typeof(Test).GetProperties().Where(p => typeof(ObservableCollection<DataElement>).IsAssignableFrom(p.PropertyType));
    
            // create a string of all properties that we are interested in with a ":1" appended so MongoDB will return these fields only
            // in our example, this will look like
            // "PartData:1,SensorData:1"
            var mongoDbProjection = string.Join(",", allPropertiesThatWeAreLookingFor.Select(p => $"{p.Name}:1"));
    
            // we do not want MongoDB to return the _id field because it's not of the selected type but would be returned by default otherwise
            mongoDbProjection += ",_id:0";
    
            var result = collection.Find(FilterDefinition<Test>.Empty).Project($"{{{mongoDbProjection}}}").ToList();
    
            Console.ReadLine();
        }
    }
