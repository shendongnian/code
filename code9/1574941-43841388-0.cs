    public class T_Blog
    {
        [Key]
        public int Id {get;set;}
        public int? FeaturedPostId {get;set;}
    
        [ForeignKey("FeaturedPostId")]
        public virtual T_Post FeaturedPost {get;set;}
        [InverseProperty("Blog")]
        public virtual ICollection<T_Post> Posts {get;set;}
    }
