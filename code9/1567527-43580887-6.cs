    public class Liabilities
    {
        //removed other collections for simplicity
        [JsonProperty(PropertyName = "Top Uncommitted Spend")]  // <-- *add this*
        public List<TopUncommittedSpend> TopUncommittedSpend { get; set; }
    }
	public class TopUncommittedSpend
	{
		public int AccountID { get; set; }
		public string H1 { get; set; }
		public string H2 { get; set; }
        //removed for simplicity
	}
