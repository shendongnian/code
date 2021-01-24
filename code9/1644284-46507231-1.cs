                var _conn = string.Format(@"mongodb://{0}:{1}@{2}:{3}/{4}"
                                    , MongoUsername
                                    , MongoPassword
                                    , MongoHost
                                    , MongoPort
                                    , MongoDatabaseName);
                var _client = new MongoClient(_conn);
                var _database = _client.GetDatabase(MongoDatabaseName);
                var twees = _database.GetCollection<Group>("tweets");
                var r = twees.AsQueryable().Select(x => x).ToList();
                Console.WriteLine(r.Count());
