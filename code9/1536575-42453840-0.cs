     string Url = "Your Url";
                   
    	HttpClient client = new HttpClient();
    	client.BaseAddress = new Uri(Url);
    	client.DefaultRequestHeaders.Accept.Clear();
    	client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    	HttpResponseMessage response = client.GetAsync(Url).Result;
    	if (response.IsSuccessStatusCode)
    	{
    		var JsonResult = response.Content.ReadAsStringAsync().Result;
    		System.Web.Script.Serialization.JavaScriptSerializer tmp = new System.Web.Script.Serialization.JavaScriptSerializer();
    		RemoteResult r = (RemoteResult)tmp.Deserialize(JsonResult, typeof(RemoteResult));
             // r.myDeserializedObjList is your desired output
        }
