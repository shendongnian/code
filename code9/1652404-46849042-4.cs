	public class Deal
	{
		public int BusinessId { get; set; } 
		[ForeignKey("BusinessId")] // I believe this attribute is redundant because the names follow conventions, but you should check that
		public virtual Business Business { get; set; }
        public bool IsEvent {get;set;}
        public int Order {get;set;}
	}
