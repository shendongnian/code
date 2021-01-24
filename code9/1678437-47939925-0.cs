     string connectionString = "mongodb://10.10.32.125:27017";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            MongoClient mongoClient = new MongoClient(settings);
            var Server = mongoClient.GetDatabase("mongovaibhav");
            var collection = Server.GetCollection<employee>("mongov");
            var filter = Builders<employee>.Filter.Eq("fname", "vaibhav");
            List<employee> emp = new List<employee>();
           foreach (var emp1 in collection.Find(filter).ToListAsync().Result )
            {
                emp.Add(emp1);
            }
            GridView1.DataSource = emp;
            GridView1.DataBind();
