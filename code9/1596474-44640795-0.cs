    #r "Newtonsoft.Json"
    using Newtonsoft.Json.Linq;
    public static void Run(string myBlob, string name, TraceWriter log)
    {
        JObject json = JObject.Parse(myBlob);
        log.Info(json.ToString());
    }
