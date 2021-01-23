    class T1
    {
        [JsonProperty("p1")]
        private object _p1;
    
        [JsonIgnore]
        public string P1
        {
            get { return _p1 as string; }
            set { _p1 = value; }
        }
    }
    var json = "{ \"p1\": {} }";
    // res.P1 is null
    var res = JsonConvert.DeserializeObject<T1>(json);
    var json2 = "{ \"p1\": \"hello\" }";
    // res2.P1 is "hello"
    var res2 = JsonConvert.DeserializeObject<T1>(json2);
