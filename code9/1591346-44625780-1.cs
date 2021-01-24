    public class UserProfile
    {
    	//other stuff...
    	[InverseProperty("Autor")]
        public ICollection<Blog> AuthoredBlogs { get; set; }
    	[InverseProperty("SubscribedUserProfiles")]
        public ICollection<Blog> SubscribedBlogs { get; set; }   
    }
    
    public class Blog
    {
        //other stuff..
    	
    	public ICollection<UserProfile> SubscribedUserProfiles { get; set; }        
    
    	public UserProfile Autor { get; set; }
    	[ForeignKey("Autor")]
    	public int AutorId { get; set; }
    }
