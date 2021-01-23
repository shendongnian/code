    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    					
    public class Program
    {
    	public class Login
        {
            public string userName { get; set; }
            public string userPass { get; set; }
    		
    		public bool isUserNameValid(string userName, string userPass, List< KeyValuePair<string, string> > validUsers) 
    		{
    			return validUsers.Any(user => user.Key == userName && user.Value == userPass ); 
    		}
        }
    	
    	static List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("dennis", "pass"),
                new KeyValuePair<string, string>("kap", "111111")
            };
    	
    	public static void Main()
    	{	Login login = new Login(); 
    		bool isValidUser = login.isUserNameValid("dennis", "pass", users); 
    		Console.WriteLine(isValidUser);
    	}
    }
