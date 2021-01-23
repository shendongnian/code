    public class Key
    {
        public int id { get; set; }
        public string name { get; set; }
        public AllocationInfo AllocationInfo { get; set; }
    }
    public class AllocationInfo
    {
        public string State { get; set; }
        public string Name { get; set; }
        public TModel TModel { get; set; }
    }
    public class TModel
    {
        public string Name { get; set; }
        public string key { get; set; }
        public v v { get; set; }
    }
    public class v
    {
        public string id { get; set; }
        public string name { get; set; }
    }
