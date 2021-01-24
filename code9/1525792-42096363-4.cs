	string url = "http://www.opole.pios.gov.pl:81/dane-pomiarowe/pobierz";
	string data = "query=" + HttpUtility.UrlEncode("{\"measType\":\"Auto\",\"viewType\":\"Station\",\"dateRange\":\"Day\",\"date\":\"07.02.2017\",\"viewTypeEntityId\":\"118\",\"channels\":[461]}");
	System.Net.WebClient wc = new System.Net.WebClient();
	wc.Headers[System.Net.HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
	string response = wc.UploadString(url, data);
	Newtonsoft.Json.Linq.JToken jsonResponse = Newtonsoft.Json.Linq.JToken.Parse(response);
	foreach (var entry in jsonResponse["data"]["series"][0]["data"])
	{
		Response.Write("epoch time: " + entry[0] + ", value: " + entry[1] + "<br>");
	}
