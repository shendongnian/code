	public class Blog
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int LatestPostId? { get; set; }
		public virtual ICollection<Post> Posts { get; set; }
		public virtual Post LatestPost
		{
			get
			{
				return Posts
					.OrderByDescending(m => m.CreatedDate)
					.FirstOrDefault();
			}
		}
	}
