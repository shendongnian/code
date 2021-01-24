    public static class UsersExtensionMethods
    {
    	public static UserVm ToVm(this User user)
    	{
    		return new UserVm
    		{
    			Name = user.Name,
    			Age = user.Age,
    			Location = user.Location
    		};
    	}
    }
    
    // by name
    public IEnumerable<UserVm> GetUsersByName (string name){
          return db.Users.Where(x=>x.Name == name).Select(u => u.ToVm()).Tolist();
    }
    
    // by age
    public IEnumerable<UserVm> GetUsersByAge (int age){
          return db.Users.Where(x=>x.Age == age).Select(u => u.ToVm()).Tolist();
    }
    
    // by age
    public IEnumerable<UserVm> GetUsersByLocation (string location){
          return db.Users.Where(x=>x.Location== location).Select(u => u.ToVm()).Tolist();
    }
