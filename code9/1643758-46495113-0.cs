    using System.Net;
    using System.Net.Http;
	
	var httpClient = new HttpClient();
    var data = "Some JSON data to be sent in your request body"; //May not need this, based on your app needs
    var contentType = "application/json"; //May vary based on your app
    var httpMethod = HttpMethod.Post; //or Get, or whatever HTTP verb your API endpoint needs
	var request = new HttpRequestMessage()
	{
		RequestUri = new Uri("http://YourWebApiUrlHere"),
		Method = httpMethod,  
		Content = new StringContent(data, System.Text.Encoding.UTF8, contentType) 
	};
	request.Headers.Add("YourHeaderName", "YourHeaderValue");
	var httpResponse = await httpClient.SendAsync(request);
	if (httpResponse.StatusCode == HttpStatusCode.OK)
	{
		//It worked, so do something
	}
	else
	{
		//It didn't work, so do something else
	}
