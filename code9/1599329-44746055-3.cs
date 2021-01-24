    var list1 = new List<User>
    	{
    		new User{Id = 1, Name = "Ted" },
    		new User{Id = 2, Name = "Jhon" },
    		new User{Id = 3, Name = "Alex" }
    	};
    var list2 = new List<User>
    	{
    		new User{Id = 2, Name = "Jhon" },
    		new User{Id = 3, Name = "Alex" },
    		new User{Id = 4, Name = "Sam" },
    	};
    
    var result = list1.Union(list2, new UserComparer());
