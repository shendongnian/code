    public class Datum
    {
        public string name { get; set; }
        public double value { get; set; }
        public string timecreated { get; set; }
    }
    public class RootObject
    {
        public List<Datum> Data { get; set; }
    }
    
    public static void Run(Stream myBlob, string name, TraceWriter log)
    {
        
        Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject> reciveList =
           new Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>();
        List<Datum> list  = reciveList.Data 
        //Do something with list.
    }
