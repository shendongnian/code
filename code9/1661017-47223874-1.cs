    class Controller
    {
    	[Messagetype("GetConnectedUsersResponse")]
    	Response GetConnectedUsers(IEnumerable<User> users)
    	{
    		//...
    	}
    	
    	[Messagetype("AnothermessageType")]
    	Response OtherStuffToDo(....)
    	{
    		//...
    	}
    }
