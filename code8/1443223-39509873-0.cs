    internal sealed class DataContextConfiguration : DbMigrationsConfiguration<DataContext>
    {
    	public Configuration()
    	{
    		AutomaticMigrationsEnabled = true;
    		AutomaticMigrationDataLossAllowed = true;
    		ContextKey = "DataContext";
    	}
    }
