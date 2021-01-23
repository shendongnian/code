	JObject jInput = new JObject();
    // Use custom serialize/deserialize setting.
	JsonSerializerSettings settings = new JsonSerializerSettings
	{
		TypeNameHandling = TypeNameHandling.Auto
	};
	JArray jArray = JArray.FromObject(list);
	string strJson = JsonConvert.SerializeObject(jArray, settings);
	jInput.Add("id", id);
	jInput.Add("strJson", strJson);
	jInput.Dump();
	
	var upsertedResult = _documentDbclient.UpsertDocumentAsync(collectionUri, jInput, null, true).Result;
	var result = _documentDbclient.ReadDocumentAsync(documentUri).Result;
	JObject jResult = (dynamic)result.Resource;
	jResult.ToString().Dump();
	
	List<Items> obj = JsonConvert.DeserializeObject<List<Items>>(jResult["strJson"].Value<string>(), settings);
