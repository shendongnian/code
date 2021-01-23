	public class Comment
	{
		public int id { get; set; }
		public string text { get; set; }
	}
	public class Comments
	{
		public List<Comment> comments { get; set; }
	}
	public class RootObject
	{
		public Dictionary<String, Comments> bugs { get; set; }
	}
	
