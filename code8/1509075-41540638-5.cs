	public class App : Application
	{
		static OpportunityModelDatabase _database;
		...
		public static OpportunityModelDatabase Database =>
			_database ?? (_database = new OpportunityModelDatabase());
	}
