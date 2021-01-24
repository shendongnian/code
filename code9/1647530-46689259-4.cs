    public class Seeder
    {
         public static void Seed(CUDbContext context)
         {
              //your seed logic...
         }
    }
    
    public  class Configuration : DbMigrationsConfiguration<CUDbContext>
    {
        //other stuff...    
    	protected override void Seed(CUDbContext context)
    	{
            Seeder.Seed(context);
    	}
    }
