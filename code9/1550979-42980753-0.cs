	using(var c = new WebClient())
	{
	    var uri = new Uri("http://localhost:62659/api/Store/GetData");
	    c.Credentials = System.Net.CredentialCache.DefaultCredentials;
	    string value = c.DownloadString(uri);
	}
