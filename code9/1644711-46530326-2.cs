	public class InboxEvent : IOwnerId
	{
		...
		[ForeignKey("Owner"), Required]
		public string OwnerId { get; set; }
        [InverseProperty("Inbox")]
		public Visitor Owner { get; set; }
		...
	}
