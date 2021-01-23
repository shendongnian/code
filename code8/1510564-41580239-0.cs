    public class Root
    {
        public List<Status> Status {get;set;}
    }
----
    var root = JsonConvert.DeserializeObject<Root>(src);
