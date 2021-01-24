    public static void report()
    {
    	//Creates the client
    	var client = new RestClient("http://example.com");
    	client.CookieContainer = new System.Net.CookieContainer();
    	client.Authenticator = new SimpleAuthenticator("username", "xxx", "password", "xxx");
    	
    	//Creates the request
    	var request = new RestRequest("/login", Method.POST);
    
    	//Executes the login request
    	var response = client.Execute(request);
    	
    	//This executes a seperate request, hence creating a new requestion
    	client.DownloadData(new RestRequest("/file", Method.GET)).SaveAs("example.csv");
    
    	Console.WriteLine(response.Content);
    }
