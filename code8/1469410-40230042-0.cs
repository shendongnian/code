    public class MyContext : DbContext 
    {
        public MyContext(): base("MyContextDB"/*the name property of your connection string*/){}
    
        //...
    }
