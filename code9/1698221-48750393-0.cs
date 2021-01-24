    dynamic res = JsonConvert.DeserializeObject(
                    "{ \"StatusCode\": 1, \"1\": { \"forename\": \"Test\", \"surname\": \"Subject\", \"addressLine1\": \"1 The Street\" }}");
                IDictionary<string, JToken> datas = res;
                foreach (var dt in datas.Skip(1))
                {
                    Info newInfo = JsonConvert.DeserializeObject<Info>(dt.Value.ToString());
                }
    public class StackOverFlow
        {
            public int StatusCode { get; set; }
            public Info Info { get; set; }
        }
    
        public class Info
        {
            public string forename { get; set; }
            public string surname { get; set; }
            public string addressLine1 { get; set; }
        }
