	class Program
	{
		public class Employee
		{
			public string Name { get; set; }
		}
		
		public class Database
		{
			public ICollection<Employee> GetCollection()
			{
				 MongoClient client = new MongoClient();
				var server = client.GetServer();
				var db = server.GetDatabase("testdb");
				var collection = db.GetCollection<Employee>("testcollection");
			}
		}
		
		public class DatabaseSeeder
		{
			private ICollection<Employee> collection;
			
			public DatabaseSeeder(ICollection<Employee> collection)
			{
				this.collection = collection;
			}
			
			public void Seed()
			{
				Random random = new Random();
				List<string> names = new List<string>() {"John","Matthew","Chris"};
				for (int i = 0; i < 5; i++)
				{
					int nameIndex      = random.Next(0, 3);  
					string nameValue   = names[nameIndex];  
					Employee employee = new Employee
					{ 
						Name = nameValue
					};
				   collection.Save(employee);
				 }
			}
		
		}
		static void Main(string[] args)
		{
			var collection = new Database().GetCollection();
			
			var databaseSeeder = new DatabaseSeeder(collection);
			
			databaseSeeder.Seed();
		}
	}
