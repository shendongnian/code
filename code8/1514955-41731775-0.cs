    using (TextFieldParser parser = new TextFieldParser(blockBlob2.OpenRead()))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters("\t");
                bool headerWritten = false;
                List<BsonDocument> listToInsert = new List<BsonDocument>();
                int chunkSize = 50;
                int counter = 0;
                var headers = new string[0];
                while (!parser.EndOfData)
                {
                    //Processing row
                    var fields = parser.ReadFields();
                    if (!headerWritten)
                    {
                        headers = fields;
                        headerWritten = true;
                        continue;
                    }
                    listToInsert.Add(new BsonDocument(headers.Zip(fields, (k, v) => new { k, v }).ToDictionary(x => x.k, x => x.v)));
                    counter++;
                    if (counter != chunkSize) continue;
                    AdditionalInformation(listToInsert, dataCollectionQueueMessage);
                    CalculateHashForPrimaryKey(listToInsert);
                    await InsertDataIntoDB(listToInsert, dataCollectionQueueMessage);
                    counter = 0;
                    listToInsert.Clear();
                }
                if (listToInsert.Count > 0)
                {
                    AdditionalInformation(listToInsert, dataCollectionQueueMessage);
                    CalculateHashForPrimaryKey(listToInsert);
                    await InsertDataIntoDB(listToInsert, dataCollectionQueueMessage);
                }
            }
     private  async Task InsertDataIntoDB(List<BsonDocument>listToInsert, DataCollectionQueueMessage dataCollectionQueueMessage)
        {
            const string connectionString = "mongodb://127.0.0.1/localdb";
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("localdb");
            var collection = _database.GetCollection<BsonDocument>(dataCollectionQueueMessage.CollectionTypeEnum.ToString());
            await collection.Indexes.CreateOneAsync(new BsonDocument("HashMultipleKey", 1), new CreateIndexOptions() { Unique = true, Sparse = true, });
            try
            {
                   await collection.InsertManyAsync(listToInsert);
            }
            catch (Exception ex)
            {
                ApplicationInsights.Instance.TrackException(ex);
                await InsertSingleDocuments(listToInsert, collection, dataCollectionQueueMessage);
            }
        }
    private  async Task InsertSingleDocuments(List<BsonDocument> dataCollectionDict, IMongoCollection<BsonDocument> collection
            ,DataCollectionQueueMessage dataCollectionQueueMessage)
        {
            ApplicationInsights.Instance.TrackEvent("About to start insert individual documents and to find the duplicate one");
            foreach (var data in dataCollectionDict)
            {
                try
                {
                     await collection.InsertOneAsync(data);
                }
                catch (Exception ex)
                {
                    ApplicationInsights.Instance.TrackException(ex,new Dictionary<string, string>() {
                        {
                            "Error Message","Duplicate document was detected, therefore ignoring this document and continuing to insert the next docuemnt"
                        }, {
                            "FilePath",dataCollectionQueueMessage.FilePath
                        }}
                    );
                }
            }
        }
