    using Newtonsoft.Json;
    
    var login = new LoginRequest
    {
    	Type = "login",
    	condition = new Dictionary<string, string>[]
    
    	{
    		new Dictionary<string, string>()
    		{
    			{"key" , "email" },
    			{"value", sUsername }
    		},
    		new Dictionary<string, string>()
    		{
    			{"key" , "password" },
    			{"value", password }
    		}
    	}
    };            
    var jsonx = JsonConvert.SerializeObject(login);
