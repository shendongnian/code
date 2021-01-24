    public class User
    {
        public ObjectId _id { get; set; }
        public string userName { get; set; }
        public string userPass { get; set; }
        public void getUser(string name , string pass)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("testdb");
            var coll = db.GetCollection<User>("user");
            List<User> list = coll.Find(x => x.userName == name && x.userPass == pass).ToList<User>();
            this = list.FirstOrDefault();
        }
    }
