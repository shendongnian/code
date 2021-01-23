    var myobjs = JsonConvert.DeserializeObject<Dictionary<string, MyObject>>(json);
    public class MyObject
    {
        public int id { get; set; }
        public string name { get; set; }
        public int var { get; set; }
        public string type { get; set; }
    }
