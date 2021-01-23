    public class Query : QueryDb<Table>
    {
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
    
        [QueryDbField(Template = "Amount = {Value} OR TotalAmount = {Value}")]
        public int AnyAmount { get; set; }
    }
