          try
            {
                await collection.InsertManyAsync(dataCollectionDict);
            }
            catch (Exception ex)
            {
                ApplicationInsights.Instance.TrackException(ex);
                InsertSingleDocuments(dataCollectionDict,collection, dataCollectionQueueMessage);
            }
        }
        private static void InsertSingleDocuments(List<BsonDocument> dataCollectionDict, IMongoCollection<BsonDocument> collection
            ,DataCollectionQueueMessage dataCollectionQueueMessage)
        {
            ApplicationInsights.Instance.TrackEvent("About to start insert individual docuemnts and to find the duplicate one");
            foreach (var data in dataCollectionDict)
            {
                try
                {
                    collection.InsertOne(data);
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
 
