	string collectionName = "YourCollectionName";
	Guid id = Guid.Parse("275319a3-d395-46f2-9370-f3eadf691e03"); // Manually set GUID for test purpose.
	
	Uri documentUri = UriFactory.CreateDocumentUri(DocumentDbDatabaseNameConfig, collectionName, id.ToString());
	Uri collectionUri = UriFactory.CreateDocumentCollectionUri(DocumentDbDatabaseNameConfig, collectionName);
    // test variables.
	var list = new List<Items>();
	list.Add(new SingleItemResponse() { Rating = 2.2d, Id = "id" });
	list.Add(new MultipletemResponse() { Rating = 2.2d, Ids = new List<string>() { "ids1", "ids2"}});
	
	JObject jInput = new JObject();
	jInput.Add("id", id);
	jInput.Add("list", JArray.FromObject(list));
	
    // Store data.
	var upsertedResult = _documentDbclient.UpsertDocumentAsync(collectionUri, jInput, null, true).Result;
	
    // Read stored data.
	var result = _documentDbclient.ReadDocumentAsync(documentUri).Result;
	JObject jResult = (dynamic)result.Resource;
	
    JArray jArray = (JArray) jResult["list"];
	foreach (var jElement in jArray)
	{
		if (jElement["Id"] != null)
		{
			SingleItemResponse single = (SingleItemResponse)jElement.ToObject(typeof(SingleItemResponse));
            // Do your job with single instance.
		}
		else if (jElement["Ids"] != null)
		{
			MultipletemResponse multiple = (MultipletemResponse)jElement.ToObject(typeof(MultipletemResponse));
            // Do your job with multiple instance.
		}
	}
