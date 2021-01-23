    public class Configuration :  DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;            
        }
