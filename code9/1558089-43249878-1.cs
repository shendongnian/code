     private static readonly string databaseName = "tomtest";
     private static readonly string collectionName = "colltest";
      // Read config
     private static readonly string endpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
     private static readonly string authorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
            var client = new DocumentClient(new Uri(endpointUrl),authorizationKey);
            Console.WriteLine();
            Console.WriteLine("**** Create Documents ****");
            Console.WriteLine();
            var document1Definition = new TestModel
            { 
                Id= Guid.NewGuid().ToString(),
                PartyId = "10114795",
                Type = "heart-rate-zone-target",
                DateStarted = DateTime.Now,
                WorkoutId = 4
            };
            var database = client.CreateDatabaseIfNotExistsAsync(new Database {Id = databaseName}).Result.Resource;
            var collection = client.CreateDocumentCollectionIfNotExistsAsync(
                UriFactory.CreateDatabaseUri(databaseName), new DocumentCollection
                {
                   Id = collectionName
                }).Result.Resource;
            //create document
            var createdocument = client.CreateDocumentAsync(collection.SelfLink, document1Definition).Result.Resource; 
