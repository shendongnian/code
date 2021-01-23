        public class DeserializedData
        {
            public string acctId { get; set; }
            public string amount { get; set; }
            public string currency { get; set; }
            public string Code { get; set; }
            public string serialNo { get; set; }
        }
    
    
    StreamReader reader = new StreamReader(streamdata);
    string res = reader.ReadToEnd();
    
    var result = JsonConvert.DeserializeObject<DeserializedData>(res);
