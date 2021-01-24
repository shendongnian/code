    public class YourContext : DbContext 
    { 
        public YourContext() 
        { 
            // Default behaviour is true
            this.Configuration.LazyLoadingEnabled = false; 
        } 
    }
