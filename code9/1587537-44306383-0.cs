        class Program
        {
            public static void Main()
            {
                string s = "{ \"10v_module\": 1, \"core_module\": 2 }";
                jsonData obj = JsonConvert.DeserializeObject<jsonData>(s);
            }
        }
    
        public class jsonData
        {
            [JsonProperty("10v_module")]
            public int v_module { get; set; }
    
            [JsonProperty("core_module")]
            public int core_module { get; set; }
        }
