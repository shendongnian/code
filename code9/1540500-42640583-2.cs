    JObject jObject = JObject.Parse(json);
    var result = (JObject)jObject["EventAppGetAllSessionByCustomerIdResult"];
    
    var dates = new List<string>();
    foreach(JProperty prop in result.Properties()) 
    {
    	if (prop.Name != "Status") 
        {
    		var data = jObject["EventAppGetAllSessionByCustomerIdResult"][prop.Name].Values<string>("SessionDate");
    		dates.AddRange(data);
    	}
    }
