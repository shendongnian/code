    using System;
    using System.Collections.Generic; 
    using System.Linq; 
    					
    public class Program
    {
    	public class Login
        {
            public string userName { get; set; }
            public string userPass { get; set; }
        }
    	
    	static List<KeyValuePair<string, string>> users = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("dennis", "pass"),
                new KeyValuePair<string, string>("kap", "111111")
            };
    	
    	public static void Main()
    	{
    		Login testLogin = new Login();
    		testLogin.userName = "dennis";
    		testLogin.userPass = "pass";	
    		bool isValidUser = users.Any(user => user.Key == testLogin.userName && user.Value == testLogin.userPass ); 
    		Console.WriteLine(isValidUser );
    	}
    }
