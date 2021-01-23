    public UserAccont login(string username, string password)
    {
            List<UserAccont> listOfUserAcconts = new List<UserAccont>();
    	
    		//Stops you throwing an Exception is username is null
    		if(listAccounts.Count() > 0 && !String.IsNullOrWhiteSpace(username))
    		{
            	return listAccounts.FirstOrDefault(acc => acc.UserName.Equals(username));
    		}
    		else
    		{
    			return listOfUserAcconts;
    		}
    }
