    public class ClassB
    {
        public ClassB(string c)
        {
            // You would like c to be reversed but it's not since it's never set via its setter.
            this.C = c;
        }
        [Reverse]
        [JsonProperty("c")]
        public string C { get; set; }
    }
