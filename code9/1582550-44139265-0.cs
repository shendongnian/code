    using Newtonsoft.Json.Linq;
    public IHttpActionResult PostList([FromBody] JObject ReceivedObjectsList)
    {           
        var receivedLists = ReceivedObjectsList.Properties();
        List<FirstObject> fo = ReceivedObjectsList["FirstObjectType"].ToObject<List<FirstObject>>();
        List<SecondObject> so = ReceivedObjectsList["SecondObjectType"].ToObject<List<SecondObject>>();
        ...
	}
