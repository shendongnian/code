        public class User
        {
            public string Name { get; set; }
            public BsonObjectId _id { get; set; }
        }
        
        IEnumerable<User> allUsers = BsonSerializer.Deserialize<IEnumerable<User>>(result);
