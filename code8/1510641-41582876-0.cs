    class Foo
    {
        string dataString;
        float[] data = null;
    
        [JsonProperty("abc")]
        public string Abc { get; set; }
    
        [JsonProperty("data")]
        public string DataString
        {
            get { return dataString; }
            set
            {
                data = null;
                dataString = value;
            }
        }
    
        [JsonIgnore]
        public float[] Data
        {
            get
            {
                if (data != null)
                    return data;
    
                return data = dataString != null ? JsonConvert.DeserializeObject<float[]>(DataString) : null;
            }
            set
            {
                DataString = value == null ? null : JsonConvert.SerializeObject(value);
            }
        }
    }
