    public class YourContext : DbContext 
    { 
        public YourContext() 
        { 
            this.Configuration.AutoDetectChangesEnabled = false; 
        }  
    }  
