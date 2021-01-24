    using System;
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;
						
	public class Program
	{
		
		public class DbSet<T> : List<T>
		{
		}
		
		public class User
		{
			public string Name {get; set; }
			public override string ToString()
			{
				return "User " + Name;
			}
		}
		
		public class Transaction
		{
			public decimal Amount {get; set; }
			public override string ToString()
			{
				return "Transaction " + Amount.ToString("0.00");
			}
		}
		
		public class DatabaseContext
		{
			public DbSet<User> GetUsers() 
			{
				return new DbSet<User>()
				{
					new User { Name = "Bob" },
					new User {Name = "Alice"}
				};
			}
			public DbSet<Transaction> GetTransactions() 
			{
				return new DbSet<Transaction>()
				{
					new Transaction { Amount = 12.34M},
					new Transaction { Amount = 56.78M}
				};
			}
	
		}
		
		public class HelperClass
		{
			private readonly DatabaseContext _db;
			
			public HelperClass(DatabaseContext db)
			{
				_db = db;
			}
			
			public DbSet<T> GetDataSource<T>()
			{
				return _db.GetType()
					.GetMethods()
					.Where( m => m.ReturnType == typeof(DbSet<T>))
					.Single()
					.Invoke(_db, new object[] {}) as DbSet<T>;
			}
			
			public IEnumerable GetDataSource(Type type)
			{
				return _db
					.GetType()
					.GetMethods()
					.Where( m => m.ReturnType == typeof(DbSet<>).MakeGenericType(new Type[] {type}))
					.Single()
					.Invoke(_db, new object[] {}) as IEnumerable;
			}
		}
		
		public static void Main()
		{
			var helperClass = new HelperClass(new DatabaseContext());
			
			foreach (var u in helperClass.GetDataSource<User>())
			{
				Console.WriteLine(u.ToString());
			}
	
			foreach (var t in helperClass.GetDataSource(typeof(Transaction)))
			{
				Console.WriteLine(t.ToString());
			}
			
		}
	}
