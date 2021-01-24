    using Newtonsoft.Json;
    
    
        using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string HtmlResult = wc.UploadString(URI, JsonConvert.SerializeObject(ServiceAndVisitroData));
                }
