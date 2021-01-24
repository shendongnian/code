    public class Account
    {
        public string Code { get; set; }
        public string Status { get; set; }
    }
    public class AccountWrapper
    {
        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
        public Account Account
        {
            get { return JsonConvert.DeserializeObject<Account>(Data); }
        }
    }
    // DeserializeObject
            string data = "{'data':'{\"Code\":\"MXXXXX\",\"Status\":\"failed\"}'}";
            var account = JsonConvert.DeserializeObject<AccountWrapper>(data).Account;
