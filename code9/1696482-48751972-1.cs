    /// <summary>
    /// Locates the first document for the given namespace in the local.oplog collection
    /// </summary>
    /// <param name="docNamespace">Namespace to search for</param>
    /// <returns>First Document found in the local.oplog collection for the specified namespace</returns>
    internal static BsonDocument GetFirstDocumentFromOpLog(string docNamespace)
    {
    	mongoClient = mongoClient ?? new MongoClient(ConnectionString);  //Create client object if it is null
    	IMongoDatabase localDB = mongoClient.GetDatabase("local");
    	var collection = localDB.GetCollection<BsonDocument>("oplog.rs");
    
    	//Find the documents from the specified namespace (DatabaseName.CollectionName), that have an operation type of "insert" (The first entry to a collection must always be an insert)
    	var filter = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>("{ $and: [ { 'ns': '" + docNamespace + "'}, { 'op': 'i'}] }");
    
    	BsonDocument retDoc = null;
    	try //to get the first document from the oplog entries
    	{		
    		retDoc = collection.Find<BsonDocument>(filter).First();
    	}
    	catch(Exception ex) { /*Logger.WriteException(ex);*/ }
    	return retDoc;
    }
    /// <summary>
    /// Takes a document from the OpLog and generates a ResumeToken
    /// </summary>
    /// <param name="firstDoc">BsonDocument from the local.oplog collection to base the ResumeToken on</param>
    /// <returns>A ResumeToken that can be provided to a collection watch (ChangeStream) that points to the firstDoc provided</returns>
    private static BsonDocument GetResumeTokenFromOpLogDoc(BsonDocument firstDoc)
    {
    	List<byte> hexVal = new List<byte>(34);
    
    	//Insert Timestamp of document
    	hexVal.Add(0x82);   //TimeStamp Tag
    	byte[] docTimeStampByteArr = BitConverter.GetBytes(firstDoc["ts"].AsBsonTimestamp.Timestamp); //Timestamp is an integer, so we need to reverse it
    	if (BitConverter.IsLittleEndian) { Array.Reverse(docTimeStampByteArr); }
    	hexVal.AddRange(docTimeStampByteArr);
    
    	//Expecting UInt64, so make sure we added 8 bytes (likely only added 4)
    	hexVal.AddRange(new byte[] { 0x00, 0x00, 0x00, 0x01 }); //Not sure why the last bytes is a 0x01, but it was present in observed ResumeTokens
    
    	//Unknown Object observed in a ResumeToken
    	//0x46 = CType::Object, followed by the string "d_id" NULL
    	//This may be something that identifies that the following value is for the "_id" field of the ObjectID given next
    	hexVal.AddRange(new byte[] { 0x46, 0x64, 0x5F, 0x69, 0x64, 0x00 }); //Unknown Object, expected to be 32 bits, with a 0x00 terminator
    
    	//Insert OID (from 0._id.ObjectID)
    	hexVal.Add(0x64);   //OID Tag
    	byte[] docByteArr = firstDoc["o"]["_id"].AsObjectId.ToByteArray();
    	hexVal.AddRange(docByteArr);
    	hexVal.Add(0x00);   //End of OID
    
    	//Insert UUID (from ui) as BinData
    	hexVal.AddRange(new byte[] { 0x5a, 0x10, 0x04 });   //0x5A = BinData, 0x10 is Length (16 bytes), 0x04 is BinDataType (newUUID)
    	hexVal.AddRange(firstDoc["ui"].AsByteArray);
    
    	hexVal.Add(0x04);   //Unknown marker (maybe end of resumeToken since 0x04 == ASCII 'EOT')
    	
    	//Package the binary data into a BsonDocument with the key "_data" and the value as a Base64 encoded string
    	BsonDocument retDoc = new BsonDocument("_data", new BsonBinaryData(hexVal.ToArray()));
    	return retDoc;
    }
    
    
    /// <summary>
    /// Example Code for setting up and resuming to the second doc
    /// </summary>
    internal static void MonitorChangeStream()
    {
    	mongoClient = mongoClient ?? new MongoClient(ConnectionString);  //Create client object if it is null
    	IMongoDatabase sandboxDB = mongoClient.GetDatabase("SandboxDB");
    	var collection = sandboxDB.GetCollection<BsonDocument>("CollectionToMonitor");
    
    	var options = new ChangeStreamOptions();
    	options.FullDocument = ChangeStreamFullDocumentOption.UpdateLookup;
    
    	try
    	{
    		var pipeline = new EmptyPipelineDefinition<ChangeStreamDocument<BsonDocument>>().Match("{ operationType: { $in: [ 'replace', 'insert', 'update' ] } }");  //Works
    		
    		//Build ResumeToken from the first document in the oplog collection
    		BsonDocument resumeTokenRefDoc = GetFirstDocumentFromOpLog(collection.CollectionNamespace.ToString());
    		if (resumeTokenRefDoc != null)
    		{
    			BsonDocument docResumeToken = GetResumeTokenFromOpLogDoc(resumeTokenRefDoc);
    			options.ResumeAfter = docResumeToken;
    		}
    
    		//Setup the ChangeStream/Watch Cursor
    		var cursor = collection.Watch(pipeline, options);
    		var enumerator = cursor.ToEnumerable().GetEnumerator();
    
    		enumerator.MoveNext();  //Blocks until a record is UPDATEd, REPLACEd or INSERTed in the database (thanks to the pipeline arg), or returns the second entry (thanks to the ResumeToken that points to the first entry)
    		
    		ChangeStreamDocument<BsonDocument> lastChangeStreamDocument = enumerator.Current;
    		//lastChangeStreamDocument is now pointing to the second entry in the oplog, or the just received entry
    		//A loop can be setup to call enumerator.MoveNext() to step through each entry in the oplog history and to also receive new events
    		
    		enumerator.Dispose();	//Be sure to dispose of the enumerator when finished.
    	}
    	catch( Exception ex)
    	{
    		//Logger.WriteException(ex);
    	}
    }
 
