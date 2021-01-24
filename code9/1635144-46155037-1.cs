    public sealed class User 
    {
    	public int Id { get; set; }	
    	public string Name { get; set; }
    
    	public IEnumerable<Post> Posts { get; set; }
    }
    
    public sealed class Post 
    {
    	public int Id { get; set; }	
    	public int UserId { get; set; }	
    	public string Title { get; set; }	
    	public string Body { get; set; }
    
    	public User User { get; set; }
    }
