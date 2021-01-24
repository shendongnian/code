    public static TResult SendReceive<TResult, TPayLoad>(string sUrl, TPayLoad sPayload)
    {
        using(WebClient webclient = new WebClient())
        {
            webclient.Headers[HttpRequestHeader.ContentType] = "application/json";
            string response = webclient.UploadString(sUrl, JsonConvert.SerializeObject(sPayload));
            TResult parsedResponse = JsonConvert.DeserializeObject<TResult>(response);
            return parsedResponse;
        }
    }
