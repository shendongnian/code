	public class PostViewModel
	{
        // Actually, you do not need UserId property
        // as it should be retrieved inside controller
        // from current user data
		public string UserId { get; set; }
		public string UserName { get; set; }
		public int PostID { get; set; }
		public string CommentMessage { get; set; }
	}
	
