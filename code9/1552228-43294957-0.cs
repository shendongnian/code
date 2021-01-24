        [HttpPost] 
        public void CreateMany(string jsonString)
        {
            //sets up mongo connection, DB and collection
            var Client = new MongoClient();
            var DB = Client.GetDatabase("PlacesDb");
            var collection = DB.GetCollection<PlaceModel>("PlaceCollection");
            if (jsonString != null)
            {
                IList<PlaceModel> documents = BsonSerializer.Deserialize<IList<PlaceModel>>(jsonString);
                collection.InsertMany(documents);
            }
        }
