    private static void Main(string[] args)
    {
    	Client.url = "https://www.url.com";
    	Client.key = Client.IssueToken("email@exampple.com", "PASSWORD", "CLIENT_NAME", "VENDOR_NAME", false);
    	var users = Client.GetJson(Client.Get("users"));
    	foreach (KeyValuePair<string, object> user in users)
    	{
    		var userProperties = (Dictionary<string, object>)user.Value;
    		Console.WriteLine(userProperties["id"].ToString() + ":\t" + userProperties["email"]);
    	}
    	Console.ReadLine();
    }
