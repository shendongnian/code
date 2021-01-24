    public class Account
    {
        public Data Data { get; set };
    }
    public class Data
    {
        public string Code{ get; set; }
        public string Status{ get; set; }
    }
    
    Account account = JsonConvert.DeserializeObject<Account>(json);
    Console.WriteLine(account .Data.Code);
