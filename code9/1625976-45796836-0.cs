    internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			using (var dc = new PeopleContext("DBConnection"))
    			{
    				//Adding entities for example
    				//AddJamesSmith(dc);
    				//AddThomasAnderson(dc);
    
    				GetWithAnonymousClass(dc);
    				GetByObject(dc);
    				GetByString(dc);
    			}
    
    			Console.ReadLine();
    		}
    
    		/// <summary>
    		/// This example shows how to select entity with children to anonymous class
    		/// plus: u can get entity with fields that u exactly need
    		/// </summary>
    		private static void GetWithAnonymousClass(PeopleContext dc)
    		{
    			Console.WriteLine("GetWithAnonymousClass:");
    			var array = dc.People.Select(c => new {c.PersonId, c.FirstName, c.LastName, c.IsAuthorised, c.IsEnabled, Colours = c.Colours.Select(cc => cc.Name)});
    			foreach (var c in array)
    				Console.WriteLine($"{c.PersonId}, {c.FirstName} {c.LastName}, {c.IsAuthorised}, {c.IsEnabled}, {string.Join(" and ", c.Colours)}");
    			Console.WriteLine();
    		}
    
    		/// <summary>
    		/// This example shows how to select entity with children and use it at client (Console.WriteLine here)
    		/// </summary>
    		/// <param name="dc"></param>
    		private static void GetByObject(PeopleContext dc)
    		{
    			Console.WriteLine("GetByObject:");
    			var array = dc.People.Include(c => c.Colours);
    			foreach (var c in array)
    				Console.WriteLine($"{c.PersonId}, {c.FirstName} {c.LastName}, {c.IsAuthorised}, {c.IsEnabled}, {string.Join(" and ", c.Colours.Select(cc => cc.Name))}");
    			Console.WriteLine();
    		}
    
    		/// This example shows how to select entity with children to string formatted at Sql-server side
    		/// plus: all code execuded at sql-server
    		/// minus: u must specify each child explicitly. U can't is this method, if u don know number of children
    		private static void GetByString(PeopleContext dc)
    		{
    			Console.WriteLine("GetByString:");
    			var array = dc.People.Select(c => c.PersonId + ", " + c.FirstName + " " + c.LastName + ", " + c.IsAuthorised +
    			                                  ", " + c.IsEnabled + ", " + c.Colours.OrderBy(сс => сс.ColourId).FirstOrDefault().Name +
    			                                  " and " + c.Colours.OrderBy(сс => сс.ColourId).Skip(1).FirstOrDefault().Name);
    
    			foreach (var c in array)
    				Console.WriteLine(c);
    			Console.WriteLine();
    		}
    
    		private static void AddJamesSmith(PeopleContext dc)
    		{
    			dc.People.Add(
    				new Person
    				{
    					FirstName = "james",
    					LastName = "smith",
    					IsAuthorised = true,
    					IsEnabled = true,
    					IsValid = true,
    					Colours = new List<Colour>
    					{
    						new Colour {IsEnabled = true, Name = "red"},
    						new Colour {IsEnabled = true, Name = "black"}
    					}
    				});
    			dc.SaveChanges();
    		}
    
    		private static void AddThomasAnderson(PeopleContext dc)
    		{
    			dc.People.Add(
    				new Person
    				{
    					FirstName = "Thomas",
    					LastName = "Anderson",
    					IsAuthorised = true,
    					IsEnabled = true,
    					IsValid = true,
    					Colours = new List<Colour>
    					{
    						new Colour {IsEnabled = true, Name = "green"},
    						new Colour {IsEnabled = true, Name = "white"}
    					}
    				});
    			dc.SaveChanges();
    		}
    	}
    
    
    	public class PeopleContext : DbContext
    	{
    		public PeopleContext(string connectionStringName) : base(connectionStringName)
    		{
    		}
    
    		public DbSet<Person> People { get; set; }
    		public DbSet<Colour> Colours { get; set; }
    	}
    
    	public class Person
    	{
    		[Key]
    		public int PersonId { get; set; }
    
    		public string FirstName { get; set; }
    
    		public string LastName { get; set; }
    
    		public bool IsAuthorised { get; set; }
    		public bool IsValid { get; set; }
    		public bool IsEnabled { get; set; }
    
    		public List<Colour> Colours { get; set; }
    	}
    
    	public class Colour
    	{
    		[Key]
    		public int ColourId { get; set; }
    
    		public string Name { get; set; }
    
    		public bool IsEnabled { get; set; }
    
    		public List<Person> People { get; set; }
    	}
