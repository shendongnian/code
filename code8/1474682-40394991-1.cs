    public class BloggingContext : DbContext 
    { 
        public BloggingContext() 
        { 
            this.Configuration.LazyLoadingEnabled = false; 
        } 
    }
