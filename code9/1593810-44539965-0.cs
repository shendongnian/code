    public class User
    {
       public string Id{get;set;}
       public string Name{get; set;}
       public string Email{get; set;}
       public ICollection<Post> Posts { get; set; }
       public ICollection<Comment> Comments { get; set; }
    }
