    public static string Method(string path)
    {
       using (var client = new HttpClient())
       {
    	   var response = client.GetAsync(path).Result;
    	   if (response.IsSuccessStatusCode)
    	   {
    			var responseContent = response.Content;
    			return responseContent.ReadAsStringAsync().Result;
    		}
    	}
     }
