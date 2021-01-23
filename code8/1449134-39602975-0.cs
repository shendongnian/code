    public class SecurityID
    {
        [JsonProperty("@idValue")]
        public string IdValue { get; set; }
        [JsonProperty("@iscalYearEnd")]
        public string FiscalYearEnd { get; set; }
    }
    public class Time
    {
        [JsonProperty("@year")]
        public string Year { get; set; }
        [JsonProperty("#text")]
        public string Text { get; set; }
    }
    public class FinancialModelItem
    {
        [JsonProperty("@name")]
        public string Name { get; set; }
        [JsonProperty("@clientCode")]
        public string ClientCode { get; set; }
        [JsonProperty("@currency")]
        public string Currency { get; set; }
        public List<Time> Value { get; set; }
    }
    public class FinancialModel
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        [JsonProperty("@name")]
        public string Name { get; set; }
        [JsonProperty("@clientCode")]
        public string ClientCode { get; set; }
        public List<FinancialModelItem> Values { get; set; }
    }
    public class FinancialModels
    {
        public List<FinancialModel> FinancialModel { get; set; }
    }
    public class Security
    {
        public SecurityID SecurityID { get; set; }
        public FinancialModels FinancialModels { get; set; }
    }
    public class SecurityDetails
    {
        public Security Security { get; set; }
    }
    public class DataFeed
    {
        [JsonProperty("@FeedName")]
        public string FeedName { get; set; }
        public SecurityDetails SecurityDetails { get; set; }
    }
    public class Xml
    {
        [JsonProperty("@version")]
        public string Version { get; set; }
        [JsonProperty("@encoding")]
        public string Encoding { get; set; }
    }
    public class RootObject
    {
        [JsonProperty("?xml")]
        public Xml Xml { get; set; }
        public DataFeed DataFeed { get; set; }
    }
