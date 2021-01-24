    private async static Task<string> SendJsonAndWait(string json, string url, string sessionId) {
        Uri uri = new Uri(url);
        string result;
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.ContentType = "application/json";
        httpWebRequest.Method = "POST";
        //Add the JSESSIONID Cookie
        if(httpWebRequest.CookieContainer == null)
                httpWebRequest.CookieContainer = new CookieContainer();
        if(!string.IsNullOrWhiteSpace(sessionId))
                httpWebRequest.CookieContainer.Add(new Cookie("JSESSIONID", sessionId, "/", uri.Host));
        using(StreamWriter streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync())) {
            await streamWriter.WriteAsync(json);
            streamWriter.Flush();
            streamWriter.Close();
        }
        HttpWebResponse httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
        Stream responseStream = httpResponse.GetResponseStream();
        if(responseStream == null)
            throw new Exception("Response Stream was null!");
        using(StreamReader streamReader = new StreamReader(responseStream)) {
            result = await streamReader.ReadToEndAsync();
        }
        return result;
    }
