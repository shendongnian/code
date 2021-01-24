    public string RunIt(string queryString, string data = null, string method = "GET")
    {
    string uriString = string.Format("{0}{1}", m_BaseUrl, queryString.ToString());
    Uri uri = new Uri(uriString);
    HttpWebRequest request = WebRequest.Create(uriString) as HttpWebRequest;
    request.ContentType = "application/json";
    request.Method = method;
    if (data != null)
    {
        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(data);
        }
    }
    string base64Credentials = GetEncodedCredentials();
    request.Headers.Add("Authorization", Convert.ToString("Basic ") + base64Credentials);
    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
    if (response.StatusCode == HttpStatusCode.NoContent)
        return "204";
    string result = string.Empty;
    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
    {
        result = reader.ReadToEnd();
    }
    return result;
    }
