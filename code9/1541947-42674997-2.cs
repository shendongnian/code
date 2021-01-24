	public class MessageThread : RealmObject
	{
		[PrimaryKey]
		public string Guid { get; set; }
		public IList<Message> Messages { get; }
	}
	public class Message : RealmObject
	{
		[PrimaryKey]
		public string Guid { get; set; }
		public string Body { get; set; }
		[Backlink(nameof(MessageThread.Guid))]
		public MessageThread Thread { get; }
	}
