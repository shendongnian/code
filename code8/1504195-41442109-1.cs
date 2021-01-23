    class Program
    {
        static bool keepRunning;
        static string fileName = "example.jpg";
        static int numDocs = 571;
        static IMongoDatabase mongoDb;
        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate
            {
                Exit();
            };
            keepRunning = true;
            SetupMongoDb();
            var fileBytes = File.ReadAllBytes(fileName);
            Console.WriteLine($"Picturesize in bytes: {fileBytes.Length}");
            ClearCollections();
            Console.WriteLine($"Saving {numDocs} pictures to the database.");
            Console.WriteLine("\nStart Saving in Binary Mode.");
            Stopwatch binaryStopWatch = Stopwatch.StartNew();
            SaveBinaryBased(numDocs, fileBytes);
            binaryStopWatch.Stop();
            Console.WriteLine("Done Saving in Binary Mode.");
            Console.WriteLine("\nStart Saving in String-based Mode.");
            Stopwatch stringStopWatch = Stopwatch.StartNew();
            SaveStringBased(numDocs, fileBytes);
            stringStopWatch.Stop();
            Console.WriteLine("Done Saving in String-based Mode.");
            Console.WriteLine("\nTime Report Saving");
            Console.WriteLine($"   * Total Time Binary for {numDocs} records: {binaryStopWatch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"   * Total Time String for {numDocs} records: {stringStopWatch.ElapsedMilliseconds} ms.");
            Console.WriteLine("\nCollection Statistics:");
            Statistics("binaryPics");
            Statistics("stringBasedPics");
            Console.WriteLine("\nTest Retrieval:");
            Console.WriteLine("\nStart Retrieving from binary collection.");
            binaryStopWatch.Restart();
            RetrieveBinary();
            binaryStopWatch.Stop();
            Console.WriteLine("Done Retrieving from binary collection.");
            Console.WriteLine("\nStart Retrieving from string-based collection.");
            stringStopWatch.Restart();
            RetrieveString();
            stringStopWatch.Stop();
            Console.WriteLine("Done Retrieving from string-based collection.");
            Console.WriteLine("\nTime Report Retrieving:");
            Console.WriteLine($"   * Total Time Binary for retrieving {numDocs} records: {binaryStopWatch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"   * Total Time String for retrieving {numDocs} records: {stringStopWatch.ElapsedMilliseconds} ms.");
            ClearGridFS();
            Console.WriteLine($"\nStart saving {numDocs} files to GridFS:");
            binaryStopWatch.Restart();
            SaveFilesToGridFS(numDocs, fileBytes);
            binaryStopWatch.Stop();
            Console.WriteLine($"Saved {numDocs} files to GridFS in {binaryStopWatch.ElapsedMilliseconds} ms.");
            Console.WriteLine($"\nStart retrieving {numDocs} files from GridFS:");
            binaryStopWatch.Restart();
            RetrieveFromGridFS();
            binaryStopWatch.Stop();
            Console.WriteLine($"Retrieved {numDocs} files from GridFS in {binaryStopWatch.ElapsedMilliseconds} ms.");
            while (keepRunning)
            {
                Thread.Sleep(500);
            }
        }
        private static void Exit()
        {
            keepRunning = false;
        }
        private static void ClearCollections()
        {
            var collectionBin = mongoDb.GetCollection<BsonDocument>("binaryPics");
            var collectionString = mongoDb.GetCollection<BsonDocument>("stringBasedPics");
            collectionBin.DeleteMany(new BsonDocument());
            collectionString.DeleteMany(new BsonDocument());
        }
        private static void SetupMongoDb()
        {
            string hostName = "localhost";
            int portNumber = 27017;
            string databaseName = "exampleSerialization";
            var clientSettings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(hostName, portNumber),
                MinConnectionPoolSize = 1,
                MaxConnectionPoolSize = 1500,
                ConnectTimeout = new TimeSpan(0, 0, 30),
                SocketTimeout = new TimeSpan(0, 1, 30),
                WaitQueueTimeout = new TimeSpan(0, 1, 0)
            };
            mongoDb = new MongoClient(clientSettings).GetDatabase(databaseName);
        }
        private static void SaveBinaryBased(int numDocuments, byte[] content)
        {
            var collection = mongoDb.GetCollection<BsonDocument>("binaryPics");
            BsonDocument baseDoc = new BsonDocument();
            baseDoc.SetElement(new BsonElement("jpgContent", content));
            for (int i = 0; i < numDocs; ++i)
            {
                baseDoc.SetElement(new BsonElement("_id", Guid.NewGuid()));
                baseDoc.SetElement(new BsonElement("filename", fileName));
                baseDoc.SetElement(new BsonElement("title", $"picture number {i}"));
                collection.InsertOne(baseDoc);
            }
        }
        private static void SaveStringBased(int numDocuments, byte[] content)
        {
            var collection = mongoDb.GetCollection<BsonDocument>("stringBasedPics");
            BsonDocument baseDoc = new BsonDocument();
            baseDoc.SetElement(new BsonElement("jpgStringContent", System.Text.Encoding.UTF8.GetString(content)));
            for (int i = 0; i < numDocs; ++i)
            {
                baseDoc.SetElement(new BsonElement("_id", Guid.NewGuid()));
                baseDoc.SetElement(new BsonElement("filename", fileName));
                baseDoc.SetElement(new BsonElement("title", $"picture number {i}"));
                collection.InsertOne(baseDoc);
            }
        }
        private static void Statistics(string collectionName)
        {
            new BsonDocument { { "collstats", collectionName } };
            var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument { { "collstats", collectionName } });
            var stats = mongoDb.RunCommand(command);
            Console.WriteLine($"  * Collection      : {collectionName}");
            Console.WriteLine($"  * Count           : {stats["count"].AsInt32} documents");
            Console.WriteLine($"  * Average Doc Size: {stats["avgObjSize"].AsInt32} bytes");
            Console.WriteLine($"  * Total Storage   : {stats["storageSize"].AsInt32} bytes");
            Console.WriteLine("\n");
        }
        private static void RetrieveBinary()
        {
            var collection = mongoDb.GetCollection<BsonDocument>("binaryPics");
            var docs = collection.Find(new BsonDocument()).ToEnumerable();
            foreach (var doc in docs)
            {
                byte[] fileArray = doc.GetElement("jpgContent").Value.AsByteArray;
                // we can simulate that we do something with the results but that's not the purpose of this experiment
                fileArray = null;
            }
        }
        private static void RetrieveString()
        {
            var collection = mongoDb.GetCollection<BsonDocument>("stringBasedPics");
            var docs = collection.Find(new BsonDocument()).ToEnumerable();
            foreach (var doc in docs)
            {
                // Simply get the string, we don't want to hit the performance test
                // with a conversion to a byte array
                string result = doc.GetElement("jpgStringContent").Value.AsString;
            }
        }
        private static void SaveFilesToGridFS(int numFiles, byte[] content)
        {
            var bucket = new GridFSBucket(mongoDb, new GridFSBucketOptions
            {
                BucketName = "pictures"
            });
            for (int i = 0; i < numFiles; ++i)
            {
                string targetFileName = $"{fileName.Substring(0, fileName.Length - ".jpg".Length)}{i}.jpg";
                int chunkSize = content.Length <= 1048576 ? 51200 : 1048576;
                bucket.UploadFromBytes(targetFileName, content, new GridFSUploadOptions { ChunkSizeBytes = chunkSize });
            }
        }
        private static void ClearGridFS()
        {
            var bucket = new GridFSBucket(mongoDb, new GridFSBucketOptions { BucketName = "pictures" });
            bucket.Drop();
        }
        private static void RetrieveFromGridFS()
        {
            var bucket = new GridFSBucket(mongoDb, new GridFSBucketOptions { BucketName = "pictures" });
            var filesIds = mongoDb.GetCollection<BsonDocument>("pictures.files").Find(new BsonDocument()).ToEnumerable().Select(doc => doc.GetElement("_id").Value);
            foreach (var id in filesIds)
            {
                var fileBytes = bucket.DownloadAsBytes(id);
                fileBytes = null;
            }
        }
    }
