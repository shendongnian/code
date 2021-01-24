    public class Response : RealmObject
    {
        //JsonConverter attribute should be decorating 'Quotation' class
        //[JsonConverter(typeof(QuotationConverter))]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<Quotation> quotationsList { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<Order> ordersList { get; }
    }
