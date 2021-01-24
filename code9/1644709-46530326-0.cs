	public class InboxEvent : IOwnerId
	{
		...
		[ForeignKey("Owner"), Required]
		public string OwnerId { get; set; }
		public Visitor Owner { get; set; }
		[ForeignKey("CausingUser")]
		public string CausingUserId { get; set; }
		public Visitor CausingUser { get; set; }
		...
	}
