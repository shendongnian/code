    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    public class User
    {
    	public string Id { get; set; }
    	public string Company { get; set; }
    	public string FName { get; set; }
    	public string LName { get; set; }
    	public string MemberLevel { get; set; }
    	public string Status { get; set; }
    }
    
    class Program
    {
    	static void CreateUser(User user)
    	{
    		using (var client = new HttpClient())
    		{
    			// posts to https://yourawesomewebsite.com/api/users
    			client.BaseAddress = new Uri("https://yourawesomewebsite.com");				
    			//client.Headers.Add("token", "validtoken");
    			HttpResponseMessage response = client.PostAsJson("api/users", user);
    			response.EnsureSuccessStatusCode();
    		}
    	}
    
    	static void Main()
    	{     
    		// Create a new user
			User user = new User
			{ 
				Id = "xxxxx",
				Company = "Test",
				FName = "Test",
				LName = "Test",
				MemberLevel = "Test",
				Status = "Active"
			};
    		
            CreateUser(user);
    	}
    }
