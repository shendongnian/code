	public class User
	{
		public int IDUser { get; set; }
	
		public virtual ICollection<Document> Documents { get; set; }
		
		...
	}
	
	public class Document
	{
		public int IDDocument { get; set; }
	
		public virtual ICollection<User> Users { get; set; }
	
		...
	}
