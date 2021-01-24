    public class RARAGA
    {
        public List<string> a { get; set; }
        public List<string> b { get; set; }
        public List<string> c { get; set; }
        public List<string> v { get; set; }
        public List<string> p { get; set; }
        public List<int> t { get; set; }
        public List<string> l { get; set; }
        public List<string> h { get; set; }
        public string o { get; set; }
    }
    JObject loObject = JObject.Parse(apiResult);
    RARAGA loRARAGA = loObject["result"].First.First.ToObject<RARAGA>();
    Console.WriteLine(loRARAGA.a[0]);
