    public sealed class Configuration : DbMigrationsConfiguration<MyDataContext>
    {
     public Configuration()
     {
       AutomaticMigrationsEnabled = false;
       ContextKey = "MySpecialKey";
     }
     //Seed method here..
    }
