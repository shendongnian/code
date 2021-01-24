    static void Main(string[] args)
    {
    	List<UserInvolvement> newUI = new List<UserInvolvement>()
    	{
    		new UserInvolvement()
    		{
    			UserId = 1,
    			Name = "AAA",
    			OtherInfo = "QQQ"
    		},
    		new UserInvolvement()
    		{
    			UserId = 2,
    			Name = "BBB",
    			OtherInfo = "123"
    		},
    		new UserInvolvement()
    		{
    			UserId = 4,
    			Name = "DDD",
    			OtherInfo = "123ert"
    		}
    
    
    	};
    
    	List<UserInvolvement> oldUI = new List<UserInvolvement>()
    	{
    		new UserInvolvement()
    		{
    			UserId = 2,
    			Name = "BBBC",
    			OtherInfo = "123"
    		},
    		new UserInvolvement()
    		{
    			UserId = 3,
    			Name = "CCC",
    			OtherInfo = "QQ44"
    		},
    		new UserInvolvement()
    		{
    			UserId = 4,
    			Name = "DDD",
    			OtherInfo = "123ert"
    		}
    
    	};
    
    	string resp = GetInvolvementLogging(newUI, oldUI);
    	WriteLine(resp);
    
    	ReadKey();
    
    	WriteLine("CU");
    }
