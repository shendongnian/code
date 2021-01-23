    public class StandardCustomers
    {
        public List<CustomersDetails> Customers_Details { get; set; }
    }
    public class CustomersDetails
    {
       [JsonProperty("id")]
       public int id { get; set; }
       [JsonProperty("name")]
       public string name { get; set; }
    }
    public class LuxuryCustomers
    {
       public List<CustomersDetails> Customers_Details { get; set; }
    }
    public class Data
    {
        public StandardCustomers standard_Customers { get; set; }
        public LuxuryCustomers luxury_Customers { get; set; }
    }
    public class RootObject
    {
       public Data data { get; set; }
    }
