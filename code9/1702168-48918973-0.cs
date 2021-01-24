    public class UserAddress
    {
	    public string Id {get;set;}
	    public string UserId {get;set;}	
    	public string StreetAddress {get;set;}
    }
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Program
    {
	    public static void Main()
    	{
		
	    	var users = new List<User>();
		    users.Add(new User { Id = "1", FirstName = "User1", LastName = "User1"});
    		users.Add(new User { Id = "2", FirstName = "User2", LastName = "User2"});
	    	users.Add(new User { Id = "3", FirstName = "User3", LastName = "User3"});
    		users.Add(new User { Id = "4", FirstName = "User4", LastName = "User4"});
    		users.Add(new User { Id = "5", FirstName = "User5", LastName = "User5"});
		
	    	var addresses  = new List<UserAddress>();
		
    		addresses.Add(new UserAddress{Id = "1", UserId = "1", StreetAddress="Street1" });
	    	addresses.Add(new UserAddress{Id = "2", UserId = "2", StreetAddress="Street2" });
    		addresses.Add(new UserAddress{Id = "3", UserId = "3", StreetAddress="Street3" });
	    	addresses.Add(new UserAddress{Id = "4", UserId = "4", StreetAddress="Street4" });
	    	var userId = "1";			
		    var q = users.Where(u => u.Id.Equals(userId))
			.Join(addresses, u => u.Id, a => a.UserId, (u,a) => new {u,a});	
		
    		Console.WriteLine(q);
		
		    var user = users.Where(u => u.Id.Equals(userId))
			.Join(addresses, u => u.Id, a => a.UserId, (u,a) => new {u,a}).Select( x => x.u).FirstOrDefault();
		
    		Console.WriteLine(user.Id);
	    	Console.WriteLine(user.FirstName);
		    Console.WriteLine(user.LastName);
	    }
    }
