    public class Rootobject
        {
            public Dictionary<string, DataObject> data { get; set; }
            public string type { get; set; }
            public string version { get; set; }
        }
        public class DataObject
        {
            public int id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public string title { get; set; }
        }
