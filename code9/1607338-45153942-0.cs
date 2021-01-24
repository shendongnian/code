    public class Person
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class StringObjectIdIdGeneratorConventionThatWorks : ConventionBase, IPostProcessingConvention
    {
        /// <summary>
        /// Applies a post processing modification to the class map.
        /// </summary>
        /// <param name="classMap">The class map.</param>
        public void PostProcess(BsonClassMap classMap)
        {
            var idMemberMap = classMap.IdMemberMap;
            if (idMemberMap == null || idMemberMap.IdGenerator != null)
                return;
            if (idMemberMap.MemberType == typeof(string))
            {
                idMemberMap.SetIdGenerator(StringObjectIdGenerator.Instance).SetSerializer(new StringSerializer(BsonType.ObjectId));
            }
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            ConventionPack cp = new ConventionPack();
            cp.Add(new StringObjectIdIdGeneratorConventionThatWorks());
            ConventionRegistry.Register("TreatAllStringIdsProperly", cp, _ => true);
    
            var collection = new MongoClient().GetDatabase("test").GetCollection<Person>("persons");
    
            Person person = new Person();
            person.Name = "Name";
            
            collection.InsertOne(person);
    
            Console.ReadLine();
        }
    }
