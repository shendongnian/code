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
            var user = coll.FirstOrDefault(x => x.userName == name && x.userPass == pass);
            if(user != null)
            {
                this._id = user._id;
                this.userName = user.userName;
                this.userPass = user.userPass;
            }
        }
    }
