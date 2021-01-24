    public class sampledata
      {
        [JsonProperty("name")]
        public string name { get; set; }
         [JsonProperty("title")]
        public string title { get; set; }
      }
     public void SampleEvent(string param)
        {
            param ="["+param+"]";//make it an array before deserialization
            List<sampledata> s = JsonConvert.DeserializeObject<List<sampledata>>(param);
         } 
