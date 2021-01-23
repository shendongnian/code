    public long getLastTimestamp()
    {
        //var tempList = getChannelNames();
        var channelList = new List<IMongoCollection<BsonDocument>>();
        var docuList = new List<BsonDocument>();
    
        foreach (var channel in getChannelNames())
        {
    		var filter = Builders<BsonDocument>.Filter.Exists("_id");
            var result = _database.GetCollection<BsonDocument>(channel.name)
    					 .FindAsync(filter).Result.ToList();
    
    		foreach (var docu in result)
            {
                Console.WriteLine(docu);
    			if (!docu["_id"].IsObjectId)
    				timeList.Add(docu["_id"].ToInt64());
            }
    		
    		return result.Where(x => !x["_id"].IsObjectId)
    			   .Max(entry => entry["_id"].ToInt64);
        }
    	
    	return 0;
    }
