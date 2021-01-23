    using (var http = new HttpClient())
    using (var response = await http.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
    using (StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync()))
    {
        var serializer = new JsonSerializer();               
        ITraceWriter tw = new MemoryTraceWriter();
        serializer.TraceWriter = tw; 
        var obj = (API_Json_Special_Feeds.RootObject)serializer.Deserialize(sr, typeof(API_Json_Special_Feeds.RootObject));
        // Stop and inspect the tracewriter object here to diagnose 
        return obj;                
    }
