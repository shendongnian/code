    static void Main(string[] args)
    {
    	var userIds = new[] { 1, 2, 3, 4, 5};
    
    	Console.WriteLine("Updating db for users...");
    
    	// Start new thread for notficiation send-out
    	Task.Run(() =>
    	{
    		foreach (var i in userIds)
    			Console.WriteLine("Sending notification for #user " + i);
    
    	}).ContinueWith(t => Console.WriteLine("Notifcation all sent!"));
    
    	Console.WriteLine("Return the result before notification all sent out!");
    }
