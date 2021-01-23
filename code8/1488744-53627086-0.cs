    private readonly CookieContainer cookieContainer = new CookieContainer();
    private string csrfToken;
    
    private void GetToken(Uri url)
    {
		var request = (HttpWebRequest) WebRequest.Create(url);
		request.Method = WebRequestMethods.Http.Get;
		request.ContentType = "application/json";
		request.Accept = "application/json";
		request.Credentials = Credentials;
		request.CookieContainer = cookieContainer;
		request.Headers["x-csrf-token"] = "Fetch";
		var response = (HttpWebResponse) request.GetResponse();
		
		csrfToken = response.Headers.Get("x-csrf-token");
    }
