    [DelimitedRecord(",")]
    [IgnoreEmptyLines]
    public class CustomerClass : 
    { 
        public string EffectiveDate;
        [FieldQuoted(QuoteMode.OptionalForRead)]
        public string CustomerID;
    }
