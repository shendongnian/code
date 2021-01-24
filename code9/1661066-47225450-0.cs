    using Newtonsoft.Json;
    class Base
    {
        public string A;
        public string B;
    }
    class Inherited : Base
    {
        public string C = "c";
    }
    // in some method
    var @base = new Base { A = "a", B = "b" };
    var inherited = JsonConvert.DeserializeObject<Inherited>(JsonConvert.SerializeObject(@base));
