    public class QueryObject
    {
        [FromQuery(Name = "Number")]
        public int Number { get; set; }
        [FromQuery(Name = "String")]
        public string String { get; set; }
    }
