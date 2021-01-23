    public static string Method(string path)
    {
       using (var client = new HttpClient())
       {
    	   var response = client.GetAsync(path).GetAwaiter().GetResult();
    	   if (response.IsSuccessStatusCode)
    	   {
    			var responseContent = response.Content;
    			return responseContent.ReadAsStringAsync().GetAwaiter().GetResult();
    		}
    	}
     }
