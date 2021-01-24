            string username = "user";
            string password = "password";
            string mongoDbAuthMechanism = "SCRAM-SHA-1";
            MongoInternalIdentity internalIdentity = 
                      new MongoInternalIdentity("admin", username);
            PasswordEvidence passwordEvidence = new PasswordEvidence(password);
            MongoCredential mongoCredential = 
                 new MongoCredential(mongoDbAuthMechanism, 
                         internalIdentity, passwordEvidence);
            List<MongoCredential> credentials = 
                       new List<MongoCredential>() {mongoCredential};
            MongoClientSettings settings = new MongoClientSettings();
            // comment this line below if your mongo doesn't run on secured mode
            settings.Credentials = credentials;
            String mongoHost = "127.0.0.1";
            MongoServerAddress address = new MongoServerAddress(mongoHost);
            settings.Server = address;
            MongoClient client = new MongoClient(settings);          
 
            var mongoServer = client.GetDatabase("myDb");
            var coll = mongoServer.GetCollection<Employee>("Employees");
            // any stubbed out class
            Employee emp = new Employee()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Employee_" + DateTime.UtcNow.ToString("yyyy_MMMM_dd")
            };
            coll.InsertOne(emp);
