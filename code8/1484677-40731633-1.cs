    public class ClassA
    {
        [JsonConstructor]
        ClassA() {}
        public ClassA(string a, ClassB b)
        {
            this.A = a;
            this.B = b;
        }
        [Reverse]
        [JsonProperty("a")]
        public string A { get; set; }
        [JsonProperty("b")]
        public ClassB B { get; set; }
    }
    public class ClassB
    {
        [JsonConstructor]
        ClassB() { }
        public ClassB(string c)
        {
            this.C = c;
        }
        [Reverse]
        [JsonProperty("c")]
        public string C { get; set; }
    }
