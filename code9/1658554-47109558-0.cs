    using(var client = new HttpClient())
    {
    	var url = new Uri(IAMSUrl + "/GetSRP");
    	var content = new StringContent("{CustomerCode: '(this should be taken from a table column)'}");
    
    	var response = await client.PostAsync(url, content);
    
    	var result = await response.Content.ReadAsStringAsync();
    
    	var objResult = JsonConvert.DeserializeObject<SrpResult>(result);
    
    	var jsonlist = JsonConvert.SerializeObject(objResult, Formatting.Indented);
    	
    	var str = "EXEC dbo.JSONToTEPP_SRP @json";
    	foreach(var json in jsonlist)
    	{
    		Sql.ExecNonQuery(str, json); 
    	}
    }
