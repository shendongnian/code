      [ImportChild]
      public class A
      {
        [JsonProperty(PropertyName = "prop_b")]
        public B PropB { get; set; }
      }
    
      public class B
      {
        [JsonProperty(PropertyName = "val1")]
        public int Val1 { get; set; }
    
        [JsonProperty(PropertyName = "val2")]
        public int Val2 { get; set; }
      }
